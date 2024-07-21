using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlumClickWinForm
{
    public partial class BlumClickForm : Form
    {
        private Bot _bot;
        private ToolTip _toolTipStart = new ToolTip();
        public BlumClickForm()
        {
            InitializeComponent();
            _bot = new Bot(this);
            Start();
        }

        private void Start()
        {
            Task.Run(async () => { await _bot.Run(); });
        }
        public void SetFormScale(int width, int height)
        {
            Width = width;
            Height = height + 240;
        }
        private void buttonRun_Click(object sender, System.EventArgs e)
        {
            _bot.SetActive(true);
            _bot.SetAutoStart(checkBoxAutoRun.Checked);
        }

        private void trackBarWidth_Scroll(object sender, System.EventArgs e)
        {
            ImageProcess.SetWidthScreenshot(trackBarWidth.Value);
        }
        private void trackBarHeight_Scroll(object sender, System.EventArgs e)
        {
            ImageProcess.SetHeightScreenshot(trackBarHeight.Value);
        }

        private void buttonHelp_Click(object sender, System.EventArgs e)
        {
            _toolTipStart.Show(
      "Nhấn CTRL để dừng bot." +
      "\nCác thanh trượt dùng để thay đổi các thông số chụp ảnh." +
      "\nĐầu tiên, hãy đặt cửa sổ BLum ở trung tâm màn hình để hoạt động chính xác." +
      "\nSau đó nhấn nút Play trong Blum. Tiếp theo nhấn nút Start trong chương trình." +
      "\nGame Auto Run chịu trách nhiệm tự động nhấn nút Play cuối game trong Blum." +
      "\n\nKhu vực càng lớn thì hiệu suất càng giảm!!!",
      buttonRun);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            Process.Start(new ProcessStartInfo("https://t.me/CoderWorker") { UseShellExecute = true });
            Process.Start(new ProcessStartInfo("https://t.me/BlumCryptoBot/app?startapp=ref_tgXDajsgLo") { UseShellExecute = true });
        }

        private void checkBoxAutoRun_CheckedChanged(object sender, System.EventArgs e)
        {
            _bot.SetAutoStart(checkBoxAutoRun.Checked);
        }
    }
}
