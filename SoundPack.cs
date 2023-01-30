using InnerLibs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;

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

        public int Duration { get; set; }
        public Key Keybind { get; set; } = default;
        public int Position { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static int GetCodeFromKey(Key Key) => Key.ToInt();

        public static Key GetKeyFromManifest(int Code)
        {
            switch (Code)
            {
                case 61010: return Key.Insert;
                case 61011: return Key.Delete;
                case 60999: return Key.Home;
                case 61007: return Key.End;
                case 61001: return Key.PageUp;
                case 61009: return Key.PageDown;
                case 61000: return Key.UpArrow;
                case 61003: return Key.LeftArrow;
                case 61005: return Key.RightArrow;
                case 61008: return Key.DownArrow;
                case 91: return Key.Unsupported;
                case 92: goto case 91;
                case 93: goto case 91;
                case 3597: goto case 91;
                default: return (Key)Code;
            }
        }

        public static Key GetSoundPackKey(Keys WindowsKey, bool Extended = false)
        {
            if (WindowsKey == Keys.Return && Extended)
                return Key.NumPadEnter;

            switch (WindowsKey)
            {
                case Keys.Escape: return Key.Escape;
                case Keys.F1: return Key.F1;
                case Keys.F2: return Key.F2;
                case Keys.F3: return Key.F3;
                case Keys.F4: return Key.F4;
                case Keys.F5: return Key.F5;
                case Keys.F6: return Key.F6;
                case Keys.F7: return Key.F7;
                case Keys.F8: return Key.F8;
                case Keys.F9: return Key.F9;
                case Keys.F10: return Key.F10;
                case Keys.F11: return Key.F11;
                case Keys.F12: return Key.F12;
                case Keys.Oemtilde: return Key.Tilde;
                case Keys.D1: return Key.D1;
                case Keys.D2: return Key.D2;
                case Keys.D3: return Key.D3;
                case Keys.D4: return Key.D4;
                case Keys.D5: return Key.D5;
                case Keys.D6: return Key.D6;
                case Keys.D7: return Key.D7;
                case Keys.D8: return Key.D8;
                case Keys.D9: return Key.D9;
                case Keys.D0: return Key.D0;
                case Keys.OemMinus: return Key.Hyphen;
                case Keys.Oemplus: return Key.Equals;
                case Keys.Back: return Key.Backspace;
                case Keys.Insert: return Key.Insert;
                case Keys.Home: return Key.Home;
                case Keys.PageUp: return Key.PageUp;
                case Keys.NumLock: return Key.NumLock;
                case Keys.Divide: return Key.Divide;
                case Keys.Multiply: return Key.Multiply;
                case Keys.Subtract: return Key.Subtract;
                case Keys.Tab: return Key.Tab;
                case Keys.Q: return Key.Q;
                case Keys.W: return Key.W;
                case Keys.E: return Key.E;
                case Keys.R: return Key.R;
                case Keys.T: return Key.T;
                case Keys.Y: return Key.Y;
                case Keys.U: return Key.U;
                case Keys.I: return Key.I;
                case Keys.O: return Key.O;
                case Keys.P: return Key.P;
                case Keys.OemOpenBrackets: return Key.OpenBracket;
                case Keys.Oem6: return Key.CloseBracket;
                case Keys.Oem5: return Key.BackSlash;
                case Keys.Delete: return Key.Delete;
                case Keys.End: return Key.End;
                case Keys.PageDown: return Key.PageDown;
                case Keys.NumPad7: return Key.NumPad7;
                case Keys.NumPad8: return Key.NumPad8;
                case Keys.NumPad9: return Key.NumPad9;
                case Keys.Add: return Key.Add;
                case Keys.CapsLock: return Key.CapsLock;
                case Keys.A: return Key.A;
                case Keys.S: return Key.S;
                case Keys.D: return Key.D;
                case Keys.F: return Key.F;
                case Keys.G: return Key.G;
                case Keys.H: return Key.H;
                case Keys.J: return Key.J;
                case Keys.K: return Key.K;
                case Keys.L: return Key.L;
                case Keys.Oem1: return Key.Semicolon;
                case Keys.Oem7: return Key.Apostrophe;
                case Keys.Return: return Key.Enter;
                case Keys.NumPad4: return Key.NumPad4;
                case Keys.NumPad5: return Key.NumPad5;
                case Keys.NumPad6: return Key.NumPad6;
                case Keys.LShiftKey: return Key.LeftShift;
                case Keys.Z: return Key.Z;
                case Keys.X: return Key.X;
                case Keys.C: return Key.C;
                case Keys.V: return Key.V;
                case Keys.B: return Key.B;
                case Keys.N: return Key.N;
                case Keys.M: return Key.M;
                case Keys.Oemcomma: return Key.Comma;
                case Keys.OemPeriod: return Key.Period;
                case Keys.OemQuestion: return Key.ForwardSlash;
                case Keys.RShiftKey: return Key.RightShift;
                case Keys.Up: return Key.UpArrow;
                case Keys.NumPad1: return Key.NumPad1;
                case Keys.NumPad2: return Key.NumPad2;
                case Keys.NumPad3: return Key.NumPad3;
                case Keys.LControlKey: return Key.LeftControl;
                case Keys.LWin: return Key.LeftWin;
                case Keys.LMenu: return Key.LeftAlt;
                case Keys.Space: return Key.Space;
                case Keys.RMenu: return Key.RightAlt;
                case Keys.RWin: return Key.RightWin;
                case Keys.Apps: return Key.Menu;
                case Keys.RControlKey: return Key.RightControl;
                case Keys.Left: return Key.LeftArrow;
                case Keys.Down: return Key.DownArrow;
                case Keys.Right: return Key.RightArrow;
                case Keys.NumPad0: return Key.NumPad0;
                case Keys.Decimal: return Key.Decimal;
                default: return Key.Unsupported;
            }
        }

        public static (Keys, bool) GetWindowsKey(Key Keybind)
        {
            switch (Keybind)
            {
                case Key.NumPadEnter: return (Keys.Return, true);
                case Key.Escape: return (Keys.Escape, false);
                case Key.F1: return (Keys.F1, false);
                case Key.F2: return (Keys.F2, false);
                case Key.F3: return (Keys.F3, false);
                case Key.F4: return (Keys.F4, false);
                case Key.F5: return (Keys.F5, false);
                case Key.F6: return (Keys.F6, false);
                case Key.F7: return (Keys.F7, false);
                case Key.F8: return (Keys.F8, false);
                case Key.F9: return (Keys.F9, false);
                case Key.F10: return (Keys.F10, false);
                case Key.F11: return (Keys.F11, false);
                case Key.F12: return (Keys.F12, false);
                case Key.Tilde: return (Keys.Oemtilde, false);
                case Key.D1: return (Keys.D1, false);
                case Key.D2: return (Keys.D2, false);
                case Key.D3: return (Keys.D3, false);
                case Key.D4: return (Keys.D4, false);
                case Key.D5: return (Keys.D5, false);
                case Key.D6: return (Keys.D6, false);
                case Key.D7: return (Keys.D7, false);
                case Key.D8: return (Keys.D8, false);
                case Key.D9: return (Keys.D9, false);
                case Key.D0: return (Keys.D0, false);
                case Key.Hyphen: return (Keys.OemMinus, false);
                case Key.Equals: return (Keys.Oemplus, false);
                case Key.Backspace: return (Keys.Back, false);
                case Key.Insert: return (Keys.Insert, false);
                case Key.Home: return (Keys.Home, false);
                case Key.PageUp: return (Keys.PageUp, false);
                case Key.NumLock: return (Keys.NumLock, false);
                case Key.Divide: return (Keys.Divide, false);
                case Key.Multiply: return (Keys.Multiply, false);
                case Key.Subtract: return (Keys.Subtract, false);
                case Key.Tab: return (Keys.Tab, false);
                case Key.Q: return (Keys.Q, false);
                case Key.W: return (Keys.W, false);
                case Key.E: return (Keys.E, false);
                case Key.R: return (Keys.R, false);
                case Key.T: return (Keys.T, false);
                case Key.Y: return (Keys.Y, false);
                case Key.U: return (Keys.U, false);
                case Key.I: return (Keys.I, false);
                case Key.O: return (Keys.O, false);
                case Key.P: return (Keys.P, false);
                case Key.OpenBracket: return (Keys.OemOpenBrackets, false);
                case Key.CloseBracket: return (Keys.Oem6, false);
                case Key.BackSlash: return (Keys.Oem5, false);
                case Key.Delete: return (Keys.Delete, false);
                case Key.End: return (Keys.End, false);
                case Key.PageDown: return (Keys.PageDown, false);
                case Key.NumPad7: return (Keys.NumPad7, false);
                case Key.NumPad8: return (Keys.NumPad8, false);
                case Key.NumPad9: return (Keys.NumPad9, false);
                case Key.Add: return (Keys.Add, false);
                case Key.CapsLock: return (Keys.CapsLock, false);
                case Key.A: return (Keys.A, false);
                case Key.S: return (Keys.S, false);
                case Key.D: return (Keys.D, false);
                case Key.F: return (Keys.F, false);
                case Key.G: return (Keys.G, false);
                case Key.H: return (Keys.H, false);
                case Key.J: return (Keys.J, false);
                case Key.K: return (Keys.K, false);
                case Key.L: return (Keys.L, false);
                case Key.Semicolon: return (Keys.Oem1, false);
                case Key.Apostrophe: return (Keys.Oem7, false);
                case Key.Enter: return (Keys.Return, false);
                case Key.NumPad4: return (Keys.NumPad4, false);
                case Key.NumPad5: return (Keys.NumPad5, false);
                case Key.NumPad6: return (Keys.NumPad6, false);
                case Key.LeftShift: return (Keys.LShiftKey, false);
                case Key.Z: return (Keys.Z, false);
                case Key.X: return (Keys.X, false);
                case Key.C: return (Keys.C, false);
                case Key.V: return (Keys.V, false);
                case Key.B: return (Keys.B, false);
                case Key.N: return (Keys.N, false);
                case Key.M: return (Keys.M, false);
                case Key.Comma: return (Keys.Oemcomma, false);
                case Key.Period: return (Keys.OemPeriod, false);
                case Key.ForwardSlash: return (Keys.OemQuestion, false);
                case Key.RightShift: return (Keys.RShiftKey, false);
                case Key.UpArrow: return (Keys.Up, false);
                case Key.NumPad1: return (Keys.NumPad1, false);
                case Key.NumPad2: return (Keys.NumPad2, false);
                case Key.NumPad3: return (Keys.NumPad3, false);
                case Key.LeftControl: return (Keys.LControlKey, false);
                case Key.LeftWin: return (Keys.LWin, false);
                case Key.LeftAlt: return (Keys.LMenu, false);
                case Key.Space: return (Keys.Space, false);
                case Key.RightAlt: return (Keys.RMenu, false);
                case Key.RightWin: return (Keys.RWin, false);
                case Key.Menu: return (Keys.Apps, false);
                case Key.RightControl: return (Keys.RControlKey, false);
                case Key.LeftArrow: return (Keys.Left, false);
                case Key.DownArrow: return (Keys.Down, false);
                case Key.RightArrow: return (Keys.Right, false);
                case Key.NumPad0: return (Keys.NumPad0, false);
                case Key.Decimal: return (Keys.Decimal, false);
                default: return (Keys.None, false);
            }
        }

        #endregion Public Methods
    }

    public class SoundPack : JsonFile
    {
        #region Public Constructors

        public SoundPack() : base()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        [IgnoreDataMember]
        public bool Active { get; set; }

        [IgnoreDataMember]
        public string AudioFilePath => Path.Combine(this.File.Directory.FullName, Sound);

        [DataMember(Name = "defines")]
        public Dictionary<string, object> Definitions { get; set; } = new Dictionary<string, object>();

        [DataMember(Name = "id")]
        public string ID { get; set; } = $"custom-sound-pack-{DateTime.Now.Ticks}";

        [IgnoreDataMember]
        public virtual bool IncludesNumPad => Keybinds.Any(x => Keymap.GetCodeFromKey(x.Keybind).IsIn(new int[17] { 69, 3637, 55, 74, 78, 3612, 83, 79, 80, 81, 75, 76, 77, 71, 72, 73, 82 }));

        [IgnoreDataMember]
        public bool IsMultikeyPack => this.KeyDefineType == "multi";

        [IgnoreDataMember]
        public IEnumerable<Keymap> Keybinds
        {
            get
            {
                var l = new List<Keymap>();
                foreach (var keybind in this.Definitions ?? new Dictionary<string, object>())
                {
                    Key key = Keymap.GetKeyFromManifest(keybind.Key.ToInt());
                    if (key != Key.Unsupported)
                    {
                        if (keybind.Value is string audiofile)
                        {
                            l.Add(new Keymap()
                            {
                                Keybind = key,
                                AudioFile = Path.Combine(this.File.Directory.FullName, audiofile)
                            });
                        }
                        else if (keybind.Value is List<object> audioPoints)
                        {
                            l.Add(new Keymap()
                            {
                                Keybind = key,
                                AudioFile = Path.Combine(this.File.Directory.FullName, this.Sound),
                                Position = audioPoints.FirstOrDefault() as int? ?? 0,
                                Duration = audioPoints.LastOrDefault() as int? ?? 0,
                            });
                        }
                        else if (keybind.Value is null)
                        {
                            //nothing to do bro
                        }
                        else
                        {
                            throw new Exception("Invalid SoundPack definition.");
                        }
                    }
                }
                if (l.Count >= 1)
                {
                    for (int i = 0; i < l.Count - 1; i++)
                        for (int j = 1; j < l.Count; j++)
                            if (Keymap.GetCodeFromKey(l[j].Keybind) > Keymap.GetCodeFromKey(l[i].Keybind))
                                (l[j], l[i]) = (l[i], l[j]);

                    (l[l.Count - 1], l[0]) = (l[0], l[l.Count - 1]);
                }

                return l.AsEnumerable();
            }
        }

        [DataMember(Name = "key_define_type")]
        public string KeyDefineType { get; set; } = "single";

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "sound")]
        public string Sound { get; set; }

        #endregion Public Properties

        #region Public Methods

        public string GetBindedAudio(Key Keybind) => Keybinds.FirstOrDefault(x => x.Keybind == Keybind)?.AudioFile ?? string.Empty;

        public int[] GetBindedRange(Key Keybind) => new int[] { GetKeyMap(Keybind).Position, GetKeyMap(Keybind).Duration };

        public Keymap GetKeyMap(Key Keybind) => Keybinds.FirstOrDefault(x => x.Keybind == Keybind);

        public SoundPack SetKeyBinds(IEnumerable<Keymap> keymaps)
        {
            this.Definitions = keymaps.ToDictionary(item => item.Keybind.ToInt().ToString(), item => this.IsMultikeyPack ? GetBindedRange(item.Keybind) as object : Path.GetFileName(item.AudioFile) as object);
            return this;
        }

        #endregion Public Methods
    }

    public enum Key
    {
        Unsupported = 0,
        Escape = 1,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        Tilde = 41,
        D1 = 2,
        D2 = 3,
        D3 = 4,
        D4 = 5,
        D5 = 6,
        D6 = 7,
        D7 = 8,
        D8 = 9,
        D9 = 10,
        D0 = 11,
        Hyphen = 12,
        Equals = 13,
        Backspace = 14,
        Tab = 15,
        CapsLock = 58,
        A = 30,
        B = 48,
        C = 46,
        D = 32,
        E = 18,
        F = 33,
        G = 34,
        H = 35,
        I = 23,
        J = 36,
        K = 37,
        L = 38,
        M = 50,
        N = 49,
        O = 24,
        P = 25,
        Q = 16,
        R = 19,
        S = 31,
        T = 20,
        U = 22,
        V = 47,
        W = 17,
        X = 45,
        Y = 21,
        Z = 44,
        OpenBracket = 26,
        CloseBracket = 27,
        BackSlash = 43,
        Semicolon = 39,
        Apostrophe = 40,
        Enter = 28,
        Comma = 51,
        Period = 52,
        ForwardSlash = 53,
        Space = 57,
        PrintScreen = 3639,
        ScrollLock = 70,
        Pause = 3653,
        Insert = 3666,
        Delete = 3667,
        Home = 3655,
        End = 3663,
        PageUp = 3657,
        PageDown = 3665,
        UpArrow = 57416,
        LeftArrow = 57419,
        RightArrow = 57421,
        DownArrow = 57424,
        LeftShift = 42,
        RightShift = 54,
        LeftControl = 29,
        RightControl = 3613,
        LeftAlt = 56,
        RightAlt = 3640,
        LeftWin = 3675,
        RightWin = 3676,
        Menu = 3677,
        NumLock = 69, // Numpad
        Divide = 3637, // Numpad
        Multiply = 55, // Numpad
        Subtract = 74, // Numpad
        Add = 78, // Numpad
        NumPadEnter = 3612, // Numpad
        Decimal = 83, // Numpad
        NumPad1 = 79, // Numpad
        NumPad2 = 80, // Numpad
        NumPad3 = 81, // Numpad
        NumPad4 = 75, // Numpad
        NumPad5 = 76, // Numpad
        NumPad6 = 77, // Numpad
        NumPad7 = 71, // Numpad
        NumPad8 = 72, // Numpad
        NumPad9 = 73, // Numpad
        NumPad0 = 82, //Numpad
    }

    /// <summary>
    /// Different states of the program
    /// </summary>
    public enum ProgramState
    {
        /// <summary>
        /// Window is visible to the user
        /// </summary>
        Visible = 0,

        /// <summary>
        /// Window is minimized the the taskbar
        /// </summary>
        Minimized = 1,

        /// <summary>
        /// Window is minimized to the system tray
        /// </summary>
        MinimizedToTray = 2
    }
}