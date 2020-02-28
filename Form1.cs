using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Amazon_cookie_loader
{
    public partial class Form1 : Form
    {
        public static string currentWorkingDir = Directory.GetCurrentDirectory();
        public Form1()
        {
            InitializeComponent();
            AREAID.SelectedIndex = 0;
        }

        private void CLEAR_COOKIE_BTN_Click(object sender, EventArgs e)
        {
            COOKIE_TEXT.Text = "";
            COOKIE_TEXT.Focus();
        }

        private void AMZ_LOGIN_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (AREAID.Text == "选择地区")
                {
                    MessageBox.Show("请先选择地区", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (COOKIE_TEXT.Text != "")
                {
                    AMZ_LOGIN_BTN.Text = "正在启动...";
                    string json_cookie = "";
                    json_cookie = COOKIE_TEXT.Text.Replace("\"\\\"", "\"").Replace("\\\"\"", "\"").Replace("\\\"", "\"").Replace("\"\"", "\"").Replace(":\",", ":\"\",");

                    ChromeDriverService chromeDriverService = null;
                    RemoteWebDriver driver = null;
                    ChromeOptions options = new ChromeOptions();
                    string chromeBinPath = currentWorkingDir + "\\ChromeBin\\chrome.exe";
                    options.BinaryLocation = chromeBinPath;
                    options.PageLoadStrategy = PageLoadStrategy.None;     //解决载入慢的问题
                    options.AddExcludedArgument("enable-automation");
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    options.AddArgument("--lang=en_US.UTF-8");//设置英文站点
                    //options.AddArgument("--user-agent=" + RandomUA());   //设置随机UA
                    options.AddArgument("--incognito");           //隐身模式
                    options.AddArgument("--disable-plugins");     //禁用插件
                    options.AddArgument("--disable-infobars");    //解决正受到自动测试软件的控制
                    options.AddArgument("--ignore-ssl-errors");
                    options.AddArgument("--ignore-certificate-errors");
                    options.AddArgument("--disable-extensions");
                    options.AddArgument("--log-level=3");
                    options.AddArgument("--disable-logging");
                    options.AddArgument("--disable-browser-side-navigation");
                    options.AddArgument("--process-per-tab");
                    options.AddArgument("--process-per-site");
                    options.AddArgument("--in-process-plugins");
                    options.AddArgument("--no-sandbox");
                    options.AddArgument("--disable-web-security");
                    options.AddArgument("--local-timezone");
                    options.AddArgument("--disable-webgl");
                    options.AddArgument("--disable-plugins-discovery");
                    options.AddArgument("--disable-timezone-tracking-option");
                    options.AddArgument("--disable-system-timezone-automatic-detection");
                    options.AddArgument("--aggressive-cache-discard");

                    if (chromeDriverService == null || chromeDriverService.ProcessId == 0)
                    {
                        chromeDriverService = ChromeDriverService.CreateDefaultService(currentWorkingDir + "\\ChromeBin\\");
                        chromeDriverService.HideCommandPromptWindow = true;
                        chromeDriverService.Start();
                    }

                    AMZ_LOGIN_BTN.Text = "打开浏览器";
                    Thread.Sleep(800);
                    driver = new RemoteWebDriver(chromeDriverService.ServiceUrl, options.ToCapabilities(), TimeSpan.FromSeconds(90));

                    driver.Manage().Window.Size = new Size(1280, 800);
                    driver.Manage().Window.Position = new Point(0, 0);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);

                    Thread.Sleep(1000);
                    driver.ExecuteScript("location.href='https://www.amazon." + AREAID.Text + "/" + 404 + "?ref=googlesearch'");
                    if (driver.Url.Contains("amazon"))
                    {
                        if (insertCookies(driver, json_cookie))
                        {
                            Thread.Sleep(1000);
                            driver.ExecuteScript("location.href='https://www.amazon." + AREAID.Text + "/?ref=nav_logo'");
                            MessageBox.Show("启动完成，使用完成后请点击“关闭浏览器”按钮清理痕迹", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先填入经过JSON校验通过的COOKIE字符串", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    COOKIE_TEXT.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("执行过程中遇到错误，错误描述：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CLOSE_AMZ_Click(object sender, EventArgs e)
        {
            KillProcessByname("chromedriver");
            KillProcessByname("chrome");
            MessageBox.Show("已完成浏览器痕迹清理", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool insertCookies(RemoteWebDriver driver, string cookiesJson)
        {
            try
            {
                if (!String.IsNullOrEmpty(cookiesJson))
                {
                    JArray cookiesJarry = (JArray)JsonConvert.DeserializeObject(cookiesJson);
                    foreach (JObject cookiesItems in cookiesJarry)
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(cookiesItems["value"])))
                        {
                            string secureNode = "";// Convert.ToString(cookiesItems["secure"]) != "False" ? "secure=Ture; " : "";
                            string domainClean = Convert.ToString(cookiesItems["domain"]);
                            if (Convert.ToString(cookiesItems["domain"]).IndexOf("www.amazon") >= 0)       //遇到有完整域名的cookie不导入
                            {
                                domainClean = domainClean.Replace("www.amazon", ".amazon");
                            }
                            driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(Convert.ToString(cookiesItems["name"]), Convert.ToString(cookiesItems["value"]), domainClean, "/", DateTime.Now.AddYears(5))); //new DateTime(1935, 12, 26)
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void KillProcessByname(string pname)
        {
            try
            {
                Process[] process = Process.GetProcesses();
                foreach (Process prs in process)
                {
                    if (prs.ProcessName == pname)
                    {
                        prs.Kill();
                    }
                }
            }
            catch { }
        }

        private void github_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/mayaxcn");
        }
    }
}
