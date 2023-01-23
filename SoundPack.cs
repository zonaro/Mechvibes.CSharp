using InnerLibs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace Mechvibes.CSharp
{
    public class Keymap
    {
        #region Public Constructors

        public Keymap() : base()
        {
        }

        #endregion Public Constructors



        #region Public Properties

        public string AudioFile { get; set; }
        public AudioRange AudioRange { get; internal set; }
        public Key Keybind { get; set; } = default;

        #endregion Public Properties
    }

    public class SoundPack : JsonFile
    {
        #region Internal Fields

        internal List<Keymap> Keybinds = new List<Keymap>();

        #endregion Internal Fields

        public string key_define_type = "single";

        public SoundPack() : base()
        {
        }

        public Dictionary<string, object> defines { get; set; } = new Dictionary<string, object>();

        public string id { get; set; } = $"custom-sound-pack-{DateTime.Now.Ticks.ToString()}";

        [IgnoreDataMember]
        public bool Active { get; set; }

        [IgnoreDataMember]
        public virtual bool IncludesNumPad
        {
            get
            {
                int[] codes = new int[17] { 69, 3637, 55, 74, 78, 3612, 83, 79, 80, 81, 75, 76, 77, 71, 72, 73, 82 };
                foreach (int code in codes)
                    foreach (Keymap keymap in Keybinds)
                        if (KeymapHelper.GetCodeFromKey(keymap.Keybind) == code)
                            return true;

                return false;
            }
        }

        public bool IsMultikeyPack => this.key_define_type == "multi";

        public string Name { get; set; }

        public string sound { get; set; }

        public SoundPack LoadBinds()
        {
            this.Keybinds = new List<Keymap>();

            foreach (var keybind in this.defines ?? new Dictionary<string, object>())
            {
                Key key = KeymapHelper.GetKeyFromManifest(int.Parse(keybind.Key));
                if (keybind.Value is string audiofile)
                {
                    audiofile = Path.Combine(this.File.Directory.FullName, audiofile);
                    this.Keybinds.Add(new Keymap() { Keybind = key, AudioFile = audiofile });
                }
                else if (keybind.Value is List<object> audioPoints)
                {

                    AudioRange audioInfo = new AudioRange
                    {
                        Position = audioPoints.FirstOrDefault() as int? ?? 0,
                        Duration = audioPoints.LastOrDefault() as int? ?? 0,
                    };

                    audiofile = Path.Combine(this.File.Directory.FullName, this.sound);
                    this.Keybinds.Add(new Keymap() { Keybind = key, AudioFile = audiofile, AudioRange = audioInfo });
                }
                else
                {
                    //throw new Exception("Invalid SoundPack definition.");
                }
            }

            this.Keybinds = Keybinds.Where(keymap => keymap.Keybind != Key.Unsupported).ToList();

            if (Keybinds.Count >= 1)
            {
                for (int i = 0; i < Keybinds.Count - 1; i++)
                    for (int j = 1; j < Keybinds.Count; j++)
                        if (KeymapHelper.GetCodeFromKey(Keybinds[j].Keybind) > KeymapHelper.GetCodeFromKey(Keybinds[i].Keybind))
                            (Keybinds[j], Keybinds[i]) = (Keybinds[i], Keybinds[j]);

                (Keybinds[Keybinds.Count - 1], Keybinds[0]) = (Keybinds[0], Keybinds[Keybinds.Count - 1]);
            }

            return this;
        }

        public string GetAudioFilePath() => Path.Combine(this.File.Directory.FullName, sound);

        public string GetBindedAudio(Key Keybind)
        {
            foreach (Keymap keymap in Keybinds)
                if (keymap.Keybind == Keybind)
                    return keymap.AudioFile;

            return string.Empty;
        }

        public AudioRange GetBindedRange(Key Keybind)
        {
            foreach (var keybind in Keybinds)
                if (keybind.Keybind == Keybind)
                    return keybind.AudioRange;

            return AudioRange.Empty;
        }


    }
}