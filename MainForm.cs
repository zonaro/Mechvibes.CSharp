using Gma.System.MouseKeyHook;
using InnerLibs;
using InnerLibs.LINQ;
using Microsoft.Win32;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private int audioVolume = 50;
        private bool m_aeroEnabled = false;
        private Keys prevKey = Keys.None;

        #endregion Private Fields

        internal static readonly List<SoundPack> soundpacks = new List<SoundPack>();
        internal readonly string SoundPacksPath = $"{Application.StartupPath}\\SoundPacks";
        internal Settings settings = new Settings();

        public MainForm()
        {
            InitializeComponent();

            string cursorPath = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Cursors").GetValue("Hand").ToString();
            IntPtr cursorHandle = string.IsNullOrEmpty(cursorPath) ? IntPtr.Zero : LoadCursorFromFile(cursorPath);
            Cursor cursorHand = cursorHandle == IntPtr.Zero ? Cursors.Hand : new Cursor(cursorHandle);

            picMinimizeToSystemTray.Cursor = cursorHand;
            picMinimize.Cursor = cursorHand;
            picClose.Cursor = cursorHand;
            cmbSelectedSoundPack.Cursor = cursorHand;
            btnReloadSoundPacks.Cursor = cursorHand;
            btnShowSoundPackFolder.Cursor = cursorHand;
            btnOpenSoundEditor.Cursor = cursorHand;
            lblGitHubAccount.Cursor = cursorHand;
            lblGitHubRepository.Cursor = cursorHand;

            void Unfocus(object sender, EventArgs e) => lblTitle.Focus();

            cmbSelectedSoundPack.SelectionChangeCommitted += new EventHandler(Unfocus);
            btnReloadSoundPacks.Click += new EventHandler(Unfocus);
            btnShowSoundPackFolder.Click += new EventHandler(Unfocus);
            btnOpenSoundEditor.Click += new EventHandler(Unfocus);

            picMinimizeToSystemTray.Image = new Bitmap(Mechvibes.CSharp.Properties.Resources.tray).Resize(picMinimizeToSystemTray.Size);
            picMinimize.Image = new Bitmap(Mechvibes.CSharp.Properties.Resources.minimize).Resize(picMinimize.Size);
            picClose.Image = new Bitmap(Mechvibes.CSharp.Properties.Resources.close).Resize(picClose.Size);

            Bitmap iconBitmap = new Bitmap(32, 32);
            using (Graphics iconGraphics = Graphics.FromImage(iconBitmap))
                iconGraphics.DrawIcon(Icon, new Rectangle(0, 0, 32, 32));

            picIcon.Image = iconBitmap;

            Timer t = new Timer { Interval = 1000 };
            t.Tick += (s, e) =>
            {
                string[] args = Environment.GetCommandLineArgs();
                args = args.Where(str_Argument => str_Argument != args.First()).ToArray();
                if (args.Length > 1)
                    switch ((ProgramState)TypeDescriptor.GetConverter(typeof(ProgramState)).ConvertFromString(args[0].Substring(2)))
                    {
                        case ProgramState.Minimized:
                            MinimizeWindow(this, EventArgs.Empty);
                            break;

                        case ProgramState.MinimizedToTray:
                            MinimizeToSystemTray(this, EventArgs.Empty);
                            break;

                        default: break;
                    }

                t.Dispose();
            };
            t.Start();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                m_aeroEnabled = CheckAeroEnabled();

                if (!m_aeroEnabled)
                    cp.ClassStyle |= 0x20000;

                return cp;
            }
        }

        internal SoundPack CurrentSoundPack => soundpacks.FirstOrDefault(soundpack => soundpack.Active);

        public ProgramState State { get; set; } = ProgramState.Visible;

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string lpFilename);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/spreadsheets/d/1PimUN_Qn3CWqfn-93YdVW8OWy8nzpz3w3me41S8S494/edit#gid=0");
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);

                return enabled == 1;
            }

            return false;
        }

        private void Close_MouseEnter(object sender, EventArgs e) => picClose.BackColor = SystemColors.Control;

        private void Close_MouseLeave(object sender, EventArgs e) => picClose.BackColor = Color.White;

        private void CloseWindow(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbSelectedSoundPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivatePack(cmbSelectedSoundPack.Text);
            textBox1.Focus();
        }

        private void DownloadDefaultPacks()
        {
            void Extract(string Resource, string File)
            {
                using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(Resource))
                using (BinaryReader br = new BinaryReader(s))
                using (FileStream fs = new FileStream(File, FileMode.OpenOrCreate))
                using (BinaryWriter bw = new BinaryWriter(fs))
                    bw.Write(br.ReadBytes((int)s.Length));
            }

            Assembly asm = Assembly.GetExecutingAssembly();

            string[] nk_cream = asm.GetManifestResourceNames().Where(name => name.Contains("nk_cream")).ToArray();

            Directory.CreateDirectory($"{SoundPacksPath}");
            Directory.CreateDirectory($"{SoundPacksPath}\\cherrymx-black-abs");
            Directory.CreateDirectory($"{SoundPacksPath}\\cherrymx-black-pbt");
            Directory.CreateDirectory($"{SoundPacksPath}\\cherrymx-blue-abs");
            Directory.CreateDirectory($"{SoundPacksPath}\\cherrymx-blue-pbt");
            Directory.CreateDirectory($"{SoundPacksPath}\\cherrymx-brown-abs");
            Directory.CreateDirectory($"{SoundPacksPath}\\cherrymx-brown-pbt");
            Directory.CreateDirectory($"{SoundPacksPath}\\cherrymx-red-abs");
            Directory.CreateDirectory($"{SoundPacksPath}\\cherrymx-red-pbt");
            Directory.CreateDirectory($"{SoundPacksPath}\\eg-crystal-purple");
            Directory.CreateDirectory($"{SoundPacksPath}\\eg-oreo");
            Directory.CreateDirectory($"{SoundPacksPath}\\nk-cream");
            Directory.CreateDirectory($"{SoundPacksPath}\\topre-purple-hybrid-pbt");

            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_black_abs.config.json", $"{SoundPacksPath}\\cherrymx-black-abs\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_black_abs.sound.wav", $"{SoundPacksPath}\\cherrymx-black-abs\\sound.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_black_pbt.config.json", $"{SoundPacksPath}\\cherrymx-black-pbt\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_black_pbt.sound.wav", $"{SoundPacksPath}\\cherrymx-black-pbt\\sound.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_blue_abs.config.json", $"{SoundPacksPath}\\cherrymx-blue-abs\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_blue_abs.sound.wav", $"{SoundPacksPath}\\cherrymx-blue-abs\\sound.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_blue_pbt.config.json", $"{SoundPacksPath}\\cherrymx-blue-pbt\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_blue_pbt.sound.wav", $"{SoundPacksPath}\\cherrymx-blue-pbt\\sound.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_brown_abs.config.json", $"{SoundPacksPath}\\cherrymx-brown-abs\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_brown_abs.sound.wav", $"{SoundPacksPath}\\cherrymx-brown-abs\\sound.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_brown_pbt.config.json", $"{SoundPacksPath}\\cherrymx-brown-pbt\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_brown_pbt.sound.wav", $"{SoundPacksPath}\\cherrymx-brown-pbt\\sound.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_red_abs.config.json", $"{SoundPacksPath}\\cherrymx-red-abs\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_red_abs.sound.wav", $"{SoundPacksPath}\\cherrymx-red-abs\\sound.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_red_pbt.config.json", $"{SoundPacksPath}\\cherrymx-red-pbt\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_red_pbt.sound.wav", $"{SoundPacksPath}\\cherrymx-red-pbt\\sound.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.eg_crystal_purple.config.json", $"{SoundPacksPath}\\eg-crystal-purple\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.eg_crystal_purple.purple.wav", $"{SoundPacksPath}\\eg-crystal-purple\\purple.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.eg_oreo.config.json", $"{SoundPacksPath}\\eg-oreo\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.eg_oreo.oreo.wav", $"{SoundPacksPath}\\eg-oreo\\oreo.wav");

            Extract("Mechvibes.CSharp.DefaultPacks.topre_purple_hybrid_pbt.config.json", $"{SoundPacksPath}\\topre-purple-hybrid-pbt\\config.json");
            Extract("Mechvibes.CSharp.DefaultPacks.topre_purple_hybrid_pbt.sound.wav", $"{SoundPacksPath}\\topre-purple-hybrid-pbt\\sound.wav");

            foreach (string nk_cream_file in nk_cream)
            {
                string[] parts = nk_cream_file.Split('.');
                string name = parts[parts.Length - 2];
                string type = parts[parts.Length - 1];

                Extract(nk_cream_file, $"{SoundPacksPath}\\nk-cream\\{name}.{type}");
            }

            LoadSoundPacks();
        }

        private void DragForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }

        private void GitHubAccount_Click(object sender, EventArgs e) => Process.Start("https://github.com/zonaro");

        private void GitHubAccount_MouseEnter(object sender, EventArgs e) => lblGitHubAccount.Font = new Font("Segoe UI", 10.0f, FontStyle.Underline);

        private void GitHubAccount_MouseLeave(object sender, EventArgs e) => lblGitHubAccount.Font = new Font("Segoe UI", 10.0f);

        private void GitHubRepository_Click(object sender, EventArgs e) => Process.Start("https://github.com/zonaro/Mechvibes.CSharp");

        private void GitHubRepository_MouseEnter(object sender, EventArgs e) => lblGitHubRepository.Font = new Font("Segoe UI", 10.0f, FontStyle.Underline);

        private void GitHubRepository_MouseLeave(object sender, EventArgs e) => lblGitHubRepository.Font = new Font("Segoe UI", 10.0f);

        private async void Keyboard_KeyDown(object sender, KeyEventArgs e)
        {
            GC.Collect();

            await Task.Run(() =>
            {
                GC.Collect();

                if (e.KeyCode != prevKey)
                {
                    if (CurrentSoundPack.IsMultikeyPack)
                    {
                        PlayAudio(CurrentSoundPack.GetBindedAudio(Keymap.GetSoundPackKey(e.KeyCode, false)), audioVolume);
                    }
                    else
                    {
                        PlayTrimmedAudio(CurrentSoundPack.AudioFilePath, audioVolume, CurrentSoundPack.GetKeyMap(Keymap.GetSoundPackKey(e.KeyCode, false)));
                    }

                    prevKey = e.KeyCode;
                }
            });

            GC.Collect();
        }

        private async void Keyboard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == prevKey) await Task.Run(() => prevKey = Keys.None);
        }

        private void LoadSoundPacks(string ActiveText = null)
        {
            cmbSelectedSoundPack.Items.Clear();
            soundpacks.Clear();
            try
            {
                foreach (string f in Directory.EnumerateDirectories(SoundPacksPath))
                {
                    SoundPack pack = new SoundPack() { FilePath = Path.Combine(f, "config.json") }.Load();

                    soundpacks.Add(pack);
                    cmbSelectedSoundPack.Items.Add(pack.Name);
                }

                if (ActiveText.IsNotBlank())
                {
                    ActiveText = ActivatePack(ActiveText)?.Name;
                    if (ActiveText.IsNotBlank())
                        cmbSelectedSoundPack.Text = ActiveText;
                    else
                        cmbSelectedSoundPack.SelectedIndex = 0;
                }
                else
                {
                    cmbSelectedSoundPack.SelectedIndex = 0;
                }

                label2.Text = $"{InnerLibs.Text.QuantifyText($"{cmbSelectedSoundPack.Items.Count} packs")} Installed";
            }
            catch (Exception)
            {
 
            }
          
        }

        private void Minimize_MouseEnter(object sender, EventArgs e) => picMinimize.BackColor = SystemColors.Control;

        private void Minimize_MouseLeave(object sender, EventArgs e) => picMinimize.BackColor = Color.White;

        private void MinimizeSysTray_MouseEnter(object sender, EventArgs e) => picMinimizeToSystemTray.BackColor = SystemColors.Control;

        private void MinimizeSysTray_MouseLeave(object sender, EventArgs e) => picMinimizeToSystemTray.BackColor = Color.White;

        private void MinimizeToSystemTray(object sender, EventArgs e)
        {
            Visible = false;
            State = ProgramState.MinimizedToTray;
        }

        private void MinimizeWindow(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            State = ProgramState.Minimized;
        }

        private void OpenSoundEditor(object sender, EventArgs e)
        {
            SoundEditor soundEditor = new SoundEditor();
            soundEditor.Shown += (s, ee) => soundEditor.Focus();
            soundEditor.Show();
        }

        private void OpenSoundPackFolder(object sender, EventArgs e) => Process.Start("explorer.exe", SoundPacksPath.CreateDirectoryIfNotExists().FullName);

        private async void PlayAudio(string file, int volume)
        {
            await Task.Run(() =>
            {
                try
                {
                    WaveOutEvent output = new WaveOutEvent
                    {
                        Volume = volume / 100.0f,
                        NumberOfBuffers = 30,
                        DesiredLatency = 150,
                    };
                    AudioFileReader audio = new AudioFileReader(file);
                    output.Init(audio);

                    output.PlaybackStopped += (s, e) =>
                    {
                        output.Dispose();
                        audio.Dispose();
                    };

                    output.Play();
                }
                catch { return; }
            });

            GC.Collect();
        }

        private async void PlayTrimmedAudio(string file, int volume, Keymap range)
        {
            await Task.Run(() =>
            {
                try
                {
                    WaveOutEvent output = new WaveOutEvent
                    {
                        Volume = volume / 100.0f,
                        NumberOfBuffers = 30,
                        DesiredLatency = 325,
                    };
                    AudioFileReader audio = new AudioFileReader(file);
                    OffsetSampleProvider trimmed = new OffsetSampleProvider(audio)
                    {
                        SkipOver = TimeSpan.FromMilliseconds(range.Position),
                        Take = TimeSpan.FromMilliseconds(range.Duration),
                    };
                    output.PlaybackStopped += (s, e) =>
                    {
                        output.Dispose();
                        audio.Dispose();
                    };
                    output.Init(trimmed);

                    output.Play();
                }
                catch (Exception)
                {
                }
            });
        }

        private void ReloadSoundPacks(object sender, EventArgs e) => LoadSoundPacks(cmbSelectedSoundPack.Text);



        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void UnminimizeWindowToNormal(object sender, EventArgs e)
        {
            Visible = true;
            State = ProgramState.Visible;
        }

        private void VolumeChanged(object sender, EventArgs e)
        {
            if (sender == trckVolume)
                numVolume.Value = audioVolume = trckVolume.Value;
            else if (sender == numVolume)
                trckVolume.Value = audioVolume = (int)numVolume.Value;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            trayicon.Visible = false;
            trayicon.Dispose();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DownloadDefaultPacks();
            settings = settings.Load();

            IKeyboardMouseEvents hook = Hook.GlobalEvents();
            hook.KeyDown += Keyboard_KeyDown;
            hook.KeyUp += Keyboard_KeyUp;

            FormClosing += (s, ee) =>
            {
                hook.KeyDown -= Keyboard_KeyDown;
                hook.KeyUp -= Keyboard_KeyUp;
                hook.Dispose();
                settings.pack = cmbSelectedSoundPack.Text;
                settings.volume = numVolume.Value.RoundInt();
                settings.Save();
            };

            settings.pack = settings.pack.IfBlank("CherryMX Black - ABS keycaps");

            if (soundpacks.Any(soundpack => soundpack.Name == settings.pack))
            {
                cmbSelectedSoundPack.Text = ActivatePack(settings.pack).Name;
            }

            if (!settings.volume.IsBetween(numVolume.Minimum.RoundInt(), numVolume.Maximum.RoundInt()))
            {
                settings.volume = 50;
            }

            numVolume.Value = settings.volume;
            trckVolume.Value = settings.volume;

            settings.Save();

            fileSystemWatcher1.Created += (s, f) =>
            {
                LoadSoundPacks(this.cmbSelectedSoundPack.Text);
            };

            fileSystemWatcher1.Changed += (s, f) =>
            {
                LoadSoundPacks(this.cmbSelectedSoundPack.Text);
            };

            fileSystemWatcher1.Deleted += (s, f) =>
            {
                LoadSoundPacks(this.cmbSelectedSoundPack.Text);
            };

            fileSystemWatcher1.Path = SoundPacksPath;
            fileSystemWatcher1.EnableRaisingEvents = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m_aeroEnabled)
            {
                int v = 2;
                DwmSetWindowAttribute(Handle, 2, ref v, 4);
                MARGINS margins = new MARGINS
                {
                    leftWidth = 0,
                    rightWidth = 0,
                    topHeight = 1,
                    bottomHeight = 0,
                };
                DwmExtendFrameIntoClientArea(Handle, ref margins);
            }

            base.WndProc(ref m);
        }

        internal SoundPack ActivatePack(string Text) => soundpacks.Each(x => x.Active = x.Name == Text).FirstOrDefault(x => x.Active);

        private struct MARGINS
        {
            #region Public Fields

            public int bottomHeight;
            public int leftWidth;
            public int rightWidth;
            public int topHeight;

            #endregion Public Fields
        }

        /// <summary>
        /// Different states of the program
        /// </summary>
        public enum ProgramState
        {
            /// <summary>
            /// Window is visible to the user
            /// </summary>
            Visible,

            /// <summary>
            /// Window is minimized the the taskbar
            /// </summary>
            Minimized,

            /// <summary>
            /// Window is minimized to the system tray
            /// </summary>
            MinimizedToTray
        }
    }
}