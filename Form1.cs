using CefSharp;
using CefSharp.WinForms;
using Knapcode.TorSharp;
using Nethereum.HdWallet;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZapperFiBalanceCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var browserList = new List<string> { "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36 Edg/119.0.0.0" };
            Random rnd = new Random();
            int index = rnd.Next(browserList.Count);
            var settings = new CefSettings();
            //settings.CefCommandLineArgs.Add("headless");
            settings.CefCommandLineArgs.Add("disable-gpu");
            settings.CefCommandLineArgs.Add("no-sandbox");
            settings.CefCommandLineArgs.Add("disable-dev-shm-usage");
            settings.CefCommandLineArgs.Add("disable-software-rasterizer");
            settings.CefCommandLineArgs.Add("disable-extensions");
            settings.CefCommandLineArgs.Add("mute-audio");
            settings.CefCommandLineArgs.Add("disable-setuid-sandbox");
            settings.CefCommandLineArgs.Add("disable-application-cache");
            settings.CefCommandLineArgs.Add("media-cache-size=1");
            settings.CefCommandLineArgs.Add("disk-cache-size=1");
            settings.CefCommandLineArgs.Add("aggressive-cache-discard");
            settings.CefCommandLineArgs.Add("start-maximized");
            settings.CefCommandLineArgs.Add("disable-infobars");
            settings.CefCommandLineArgs.Add("disable-notifications");
            settings.CefCommandLineArgs.Add("disable-offline-auto-reload");
            settings.CefCommandLineArgs.Add("disable-offline-auto-reload-visible-only");
            settings.CefCommandLineArgs.Add("blink-settings=imagesEnabled=false");
            //settings.CefCommandLineArgs.Add("disable-image-loading");
            settings.UserAgent = browserList[index];
            Cef.Initialize(settings);
            InitializeComponent();
        }
        bool isTorRunning1 = false;
        private string balance1;
        private string previousBalance1;
        private string url1;
        private bool stop1 = false;
        bool isTorRunning2 = false;
        private string balance2;
        private string previousBalance2;
        private string url2;
        private bool stop2 = false;
        bool isTorRunning3 = false;
        private string balance3;
        private string previousBalance3;
        private string url3;
        private bool stop3 = false;
        bool isTorRunning4 = false;
        private string balance4;
        private string previousBalance4;
        private string url4;
        private bool stop4 = false;

        static string GetAccountAddress1(string privatekey)
        {
            var account = new Account(privatekey);
            return account.Address;
        }
        static string GetAccountAddress2(string privatekey)
        {
            var account = new Account(privatekey);
            return account.Address;
        }
        static string GetAccountAddress3(string privatekey)
        {
            var account = new Account(privatekey);
            return account.Address;
        }
        static string GetAccountAddress4(string privatekey)
        {
            var account = new Account(privatekey);
            return account.Address;
        }
        private void chromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading && button1.Text != "Click After Cloudflare Check")
            {
                Console.WriteLine("Page Loaded");
            }


        }
        private void chromiumWebBrowser2_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading && button2.Text != "Click After Cloudflare Check")
            {
                Console.WriteLine("Page Loaded");
            }
        }
        private void chromiumWebBrowser3_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading && button3.Text != "Click After Cloudflare Check")
            {
                Console.WriteLine("Page Loaded");
            }
        }
        private void chromiumWebBrowser4_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading && button4.Text != "Click After Cloudflare Check")
            {
                Console.WriteLine("Page Loaded");
            }
        }

        private async Task<string> returnBalance1()
        {
            Console.WriteLine("Returning Balance");
            await Task.Delay(TimeSpan.FromSeconds(1));

            try
            {
                string script = "document.querySelector('div[title=\"Click to toggle between USD and ETH\"]').textContent";
                var result = await chromiumWebBrowser1.EvaluateScriptAsync(script);
                if (result.Success && result.Result != null)
                {
                    previousBalance1 = balance1;
                    balance1 = result.Result.ToString();
                }
                else
                {
                    string script1 = "document.body.innerText.includes('Checking if the site connection is secure')";
                    var result1 = await chromiumWebBrowser1.EvaluateScriptAsync(script1);
                    if (result1.Success && result1.Result != null && (bool)result1.Result)
                    {
                        stop1 = true;
                    }
                    else
                    {
                        previousBalance1 = balance1;
                        balance1 = "0";
                    }
                }
            }
            catch (Exception err)
            {
                FileStream fs = new FileStream("addr_balances_error.txt", FileMode.Append);
                TextWriter sw = new StreamWriter(fs);
                sw.WriteLine("Error: " + err.ToString());
                sw.Close();
            }
            return balance1;

        }
        private async Task<string> returnBalance2()
        {
            Console.WriteLine("Returning Balance");
            await Task.Delay(TimeSpan.FromSeconds(1));

            try
            {
                string script = "document.querySelector('div[title=\"Click to toggle between USD and ETH\"]').textContent";
                var result = await chromiumWebBrowser2.EvaluateScriptAsync(script);
                if (result.Success && result.Result != null)
                {
                    previousBalance2 = balance2;
                    balance2 = result.Result.ToString();
                }
                else
                {
                    string script1 = "document.body.innerText.includes('Checking if the site connection is secure')";
                    var result1 = await chromiumWebBrowser2.EvaluateScriptAsync(script1);
                    if (result1.Success && result1.Result != null && (bool)result1.Result)
                    {
                        stop2 = true;
                    }
                    else
                    {
                        previousBalance2 = balance2;
                        balance2 = "0";
                    }
                }
            }
            catch (Exception err)
            {
                FileStream fs = new FileStream("addr_balances_error2.txt", FileMode.Append);
                TextWriter sw = new StreamWriter(fs);
                sw.WriteLine("Error: " + err.ToString());
                sw.Close();
            }
            return balance2;

        }
        private async Task<string> returnBalance3()
        {
            Console.WriteLine("Returning Balance");
            await Task.Delay(TimeSpan.FromSeconds(1));

            try
            {
                string script = "document.querySelector('div[title=\"Click to toggle between USD and ETH\"]').textContent";
                var result = await chromiumWebBrowser3.EvaluateScriptAsync(script);
                if (result.Success && result.Result != null)
                {
                    previousBalance3 = balance3;
                    balance3 = result.Result.ToString();
                }
                else
                {
                    string script1 = "document.body.innerText.includes('Checking if the site connection is secure')";
                    var result1 = await chromiumWebBrowser3.EvaluateScriptAsync(script1);
                    if (result1.Success && result1.Result != null && (bool)result1.Result)
                    {
                        stop3 = true;
                    }
                    else
                    {
                        previousBalance3 = balance3;
                        balance3 = "0";
                    }
                }
            }
            catch (Exception err)
            {
                FileStream fs = new FileStream("addr_balances_error3.txt", FileMode.Append);
                TextWriter sw = new StreamWriter(fs);
                sw.WriteLine("Error: " + err.ToString());
                sw.Close();
            }
            return balance3;

        }
        private async Task<string> returnBalance4()
        {
            Console.WriteLine("Returning Balance");
            await Task.Delay(TimeSpan.FromSeconds(1));

            try
            {
                string script = "document.querySelector('div[title=\"Click to toggle between USD and ETH\"]').textContent";
                var result = await chromiumWebBrowser4.EvaluateScriptAsync(script);
                if (result.Success && result.Result != null)
                {
                    previousBalance4 = balance4;
                    balance4 = result.Result.ToString();
                }
                else
                {
                    string script1 = "document.body.innerText.includes('Checking if the site connection is secure')";
                    var result1 = await chromiumWebBrowser4.EvaluateScriptAsync(script1);
                    if (result1.Success && result1.Result != null && (bool)result1.Result)
                    {
                        stop4 = true;
                    }
                    else
                    {
                        previousBalance4 = balance4;
                        balance4 = "0";
                    }
                }
            }
            catch (Exception err)
            {
                FileStream fs = new FileStream("addr_balances_error4.txt", FileMode.Append);
                TextWriter sw = new StreamWriter(fs);
                sw.WriteLine("Error: " + err.ToString());
                sw.Close();
            }
            return balance4;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Click After Cloudflare Check")
            {
                stop1 = false;
                button1.Text = "Started";
                button1.Enabled = false;

                string[] inputFiles = Directory.GetFiles(Environment.CurrentDirectory, "addresses1.txt", SearchOption.TopDirectoryOnly);

                int seedpos = -1;

                string seed = "";

                foreach (string file in inputFiles)
                {
                    if (stop1 == true)
                    {
                        break;
                    }
                    string[] lines = File.ReadAllLines(file);
                    int linescount = 0;
                    foreach (string line in lines)
                    {
                        button1.Text = linescount.ToString() + "/" + lines.Length;
                        linescount++;
                        FileStream fs2 = new FileStream("addr_balances1.txt", FileMode.Append);
                        TextWriter sw2 = new StreamWriter(fs2);
                        try
                        {
                            if (line.StartsWith(seedpos.ToString()) || line.StartsWith("Zapper URL : ") || line.StartsWith("Debank URL : ") || line.StartsWith("Account Balance : ") || line.Contains("BTC Legacy Address") || line.Contains("BTC Segwit Address:") || line.Contains("BTC Segwit P2SH Address"))
                            {
                                sw2.Close();
                                continue;
                            }

                            if (line.Contains("Seed: "))
                            {
                                sw2.WriteLine(line);
                                seedpos = Convert.ToInt32(line.Substring(0, line.IndexOf(" ")));
                                seed = line.TextAfter("Seed: ");
                                previousBalance1 = "-1";

                                for (int i = 0; i < 99; i++)
                                {
                                    if (i > 2 && previousBalance1 == "0")
                                    {
                                        break;
                                    }
                                    var account = new Wallet(seed, "").GetAccount(i);
                                    var publicKey = GetAccountAddress1(account.PrivateKey);
                                    sw2.WriteLine(seedpos + " - PrivateKey: " + account.PrivateKey);
                                    url1 = "https://zapper.xyz/account/" + publicKey;
                                    textBox1.Text = url1;
                                    sw2.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                    sw2.WriteLine("Zapper URL : " + url1);
                                    sw2.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);

                                    Console.WriteLine("Navigating Page");
                                    await chromiumWebBrowser1.LoadUrlAsync(url1);
                                    Console.WriteLine("Balance Fetched");
                                    await returnBalance1();
                                    sw2.WriteLine("Account Balance : " + balance1);
                                    if (balance1.Contains("$")) { balance1 = balance1.Replace("$", ""); }
                                    if (balance1.Contains(",")) { balance1 = balance1.Replace(",", ""); }
                                    if (balance1.Contains(".")) { balance1 = balance1.Replace(".", ","); }

                                    double.TryParse(balance1, out double balance1Double); if (balance1Double > 50)
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream("addr_big_balances1.txt", FileMode.Append);
                                            TextWriter sw = new StreamWriter(fs);
                                            sw.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                            sw.WriteLine("Zapper URL : " + url1);
                                            sw.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                            sw.WriteLine("Account Balance : " + balance1Double);
                                            sw.Close();
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                FileStream fs1 = new FileStream("addr_big_balances2.txt", FileMode.Append);
                                                TextWriter sw1 = new StreamWriter(fs1);
                                                sw1.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                sw1.WriteLine("Zapper URL : " + url1);
                                                sw1.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                sw1.WriteLine("Account Balance : " + balance1Double);
                                                sw1.Close();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    FileStream fs3 = new FileStream("addr_big_balances3.txt", FileMode.Append);
                                                    TextWriter sw3 = new StreamWriter(fs3);
                                                    sw3.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw3.WriteLine("Zapper URL : " + url1);
                                                    sw3.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw3.WriteLine("Account Balance : " + balance1Double);
                                                    sw3.Close();
                                                }
                                                catch
                                                {
                                                    FileStream fs4 = new FileStream("addr_big_balances4.txt", FileMode.Append);
                                                    TextWriter sw4 = new StreamWriter(fs4);
                                                    sw4.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw4.WriteLine("Zapper URL : " + url1);
                                                    sw4.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw4.WriteLine("Account Balance : " + balance1Double);
                                                    sw4.Close();

                                                }

                                            }

                                        }

                                    }

                                }
                                sw2.Close();

                            }
                            else
                            {
                                if (line.Contains("Address: "))
                                {
                                    sw2.WriteLine(line);
                                    url1 = "https://zapper.xyz/account/" + line.TextAfter("Address: ");
                                    textBox1.Text = url1;
                                    sw2.WriteLine("Zapper URL : " + url1);
                                    sw2.WriteLine("Debank URL : " + "https://debank.com/profile/" + line.TextAfter("Address: "));
                                    Console.WriteLine("Navigating Page");
                                    await chromiumWebBrowser1.LoadUrlAsync(url1);
                                    Console.WriteLine("Balance Fetched");
                                    await returnBalance1();
                                    sw2.WriteLine("Account Balance : " + balance1);

                                    string publicKey = line.TextAfter("Address: ");
                                    if (balance1.Contains("$")) { balance1 = balance1.Replace("$", ""); }
                                    if (balance1.Contains(",")) { balance1 = balance1.Replace(",", ""); }
                                    if (balance1.Contains(".")) { balance1 = balance1.Replace(".", ","); }

                                    double.TryParse(balance1, out double balance1Double); if (balance1Double > 50)
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream("addr_big_balances1.txt", FileMode.Append);
                                            TextWriter sw = new StreamWriter(fs);
                                            sw.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                            sw.WriteLine("Zapper URL : " + url1);
                                            sw.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                            sw.WriteLine("Account Balance : " + balance1Double);
                                            sw.Close();
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                FileStream fs1 = new FileStream("addr_big_balances2.txt", FileMode.Append);
                                                TextWriter sw1 = new StreamWriter(fs1);
                                                sw1.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                sw1.WriteLine("Zapper URL : " + url1);
                                                sw1.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                sw1.WriteLine("Account Balance : " + balance1Double);
                                                sw1.Close();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    FileStream fs3 = new FileStream("addr_big_balances3.txt", FileMode.Append);
                                                    TextWriter sw3 = new StreamWriter(fs3);
                                                    sw3.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw3.WriteLine("Zapper URL : " + url1);
                                                    sw3.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw3.WriteLine("Account Balance : " + balance1Double);
                                                    sw3.Close();
                                                }
                                                catch
                                                {
                                                    FileStream fs4 = new FileStream("addr_big_balances4.txt", FileMode.Append);
                                                    TextWriter sw4 = new StreamWriter(fs4);
                                                    sw4.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw4.WriteLine("Zapper URL : " + url1);
                                                    sw4.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw4.WriteLine("Account Balance : " + balance1Double);
                                                    sw4.Close();

                                                }

                                            }

                                        }

                                    }
                                    sw2.Close();






                                }
                                else
                                {
                                    sw2.WriteLine(line);
                                    sw2.Close();

                                }
                            }

                        }
                        catch (Exception err)
                        {
                            FileStream fs = new FileStream("addr_balances_error1.txt", FileMode.Append);
                            TextWriter sw = new StreamWriter(fs);
                            sw.WriteLine("Error: " + err.ToString());
                            sw.Close();
                            sw2.Close();
                            continue;
                        }



                    }
                }


                //chromiumWebBrowser1.Reload(true);
            }
            else
            {
                button1.Text = "Click After Cloudflare Check";
                button1.Enabled = false;
                // configure
                var settings = new TorSharpSettings
                {
                    ZippedToolsDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TorZipped1"),
                    ExtractedToolsDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TorExtracted1"),
                    PrivoxySettings = { Port = 1117 },
                    TorSettings =
                    {
                      SocksPort = 1118,
                      ControlPort = 1119,
                      ControlPassword = "",
                    },
                };

                // download tools
                await new TorSharpToolFetcher(settings, new HttpClient()).FetchAsync();
                // execute
                var proxy = new TorSharpProxy(settings);
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxySettings.Port))
                };
                var httpClient = new HttpClient(handler);

                if (isTorRunning1 == false)
                {
                    await proxy.ConfigureAndStartAsync();

                    isTorRunning1 = true;
                }


                await Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    string ip = "127.0.0.1";
                    string port = "1117";
                    var rc = chromiumWebBrowser1.GetBrowser().GetHost().RequestContext;
                    var dict = new Dictionary<string, object>
                    {
                    { "mode", "fixed_servers" },
                    { "server", "" + ip + ":" + port + "" }
                    };
                    string error;
                    bool success = rc.SetPreference("proxy", dict, out error);

                });

                url1 = textBox1.Text;
                await chromiumWebBrowser1.LoadUrlAsync(url1);
                button1.Enabled = true;

            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Click After Cloudflare Check")
            {
                stop2 = false;
                button2.Text = "Started";
                button2.Enabled = false;

                string[] inputFiles = Directory.GetFiles(Environment.CurrentDirectory, "addresses2.txt", SearchOption.TopDirectoryOnly);

                int seedpos = -1;

                string seed = "";

                foreach (string file in inputFiles)
                {
                    if (stop2 == true)
                    {
                        break;
                    }
                    string[] lines = File.ReadAllLines(file);
                    int linescount = 0;
                    foreach (string line in lines)
                    {
                        button2.Text = linescount.ToString() + "/" + lines.Length;
                        linescount++;
                        FileStream fs2 = new FileStream("addr_balances2.txt", FileMode.Append);
                        TextWriter sw2 = new StreamWriter(fs2);
                        try
                        {
                            if (line.StartsWith(seedpos.ToString()) || line.StartsWith("Zapper URL : ") || line.StartsWith("Debank URL : ") || line.StartsWith("Account Balance : "))
                            {
                                sw2.Close();
                                continue;
                            }


                            if (line.Contains("Seed: "))
                            {
                                sw2.WriteLine(line);
                                seedpos = Convert.ToInt32(line.Substring(0, line.IndexOf(" ")));
                                seed = line.TextAfter("Seed: ");
                                previousBalance2 = "-1";

                                for (int i = 0; i < 99; i++)
                                {
                                    if (i > 2 && previousBalance2 == "0")
                                    {
                                        break;
                                    }
                                    var account = new Wallet(seed, "").GetAccount(i);
                                    var publicKey = GetAccountAddress2(account.PrivateKey);
                                    sw2.WriteLine(seedpos + " - PrivateKey: " + account.PrivateKey);
                                    url2 = "https://zapper.xyz/account/" + publicKey;
                                    textBox2.Text = url2;
                                    sw2.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                    sw2.WriteLine("Zapper URL : " + url2);
                                    sw2.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);

                                    Console.WriteLine("Navigating Page");
                                    await chromiumWebBrowser2.LoadUrlAsync(url2);
                                    Console.WriteLine("Balance Fetched");
                                    await returnBalance2();
                                    sw2.WriteLine("Account Balance : " + balance2);
                                    if (balance2.Contains("$")) { balance2 = balance2.Replace("$", ""); }
                                    if (balance2.Contains(",")) { balance2 = balance2.Replace(",", ""); }
                                    if (balance2.Contains(".")) { balance2 = balance2.Replace(".", ","); }
                                    double.TryParse(balance2, out double balance2Double); if (balance2Double > 50)
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream("addr_big_balances1.txt", FileMode.Append);
                                            TextWriter sw = new StreamWriter(fs);
                                            sw.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                            sw.WriteLine("Zapper URL : " + url1);
                                            sw.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                            sw.WriteLine("Account Balance : " + balance2Double);
                                            sw.Close();
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                FileStream fs1 = new FileStream("addr_big_balances2.txt", FileMode.Append);
                                                TextWriter sw1 = new StreamWriter(fs1);
                                                sw1.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                sw1.WriteLine("Zapper URL : " + url1);
                                                sw1.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                sw1.WriteLine("Account Balance : " + balance2Double);
                                                sw1.Close();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    FileStream fs3 = new FileStream("addr_big_balances3.txt", FileMode.Append);
                                                    TextWriter sw3 = new StreamWriter(fs3);
                                                    sw3.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw3.WriteLine("Zapper URL : " + url1);
                                                    sw3.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw3.WriteLine("Account Balance : " + balance2Double);
                                                    sw3.Close();
                                                }
                                                catch
                                                {
                                                    FileStream fs4 = new FileStream("addr_big_balances4.txt", FileMode.Append);
                                                    TextWriter sw4 = new StreamWriter(fs4);
                                                    sw4.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw4.WriteLine("Zapper URL : " + url1);
                                                    sw4.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw4.WriteLine("Account Balance : " + balance2Double);
                                                    sw4.Close();

                                                }

                                            }

                                        }

                                    }
                                }
                                sw2.Close();

                            }
                            else
                            {
                                if (line.Contains("Address: "))
                                {
                                    sw2.WriteLine(line);
                                    url2 = "https://zapper.xyz/account/" + line.TextAfter("Address: ");
                                    textBox2.Text = url2;
                                    sw2.WriteLine("Zapper URL : " + url2);
                                    sw2.WriteLine("Debank URL : " + "https://debank.com/profile/" + line.TextAfter("Address: "));
                                    Console.WriteLine("Navigating Page");
                                    await chromiumWebBrowser2.LoadUrlAsync(url2);
                                    Console.WriteLine("Balance Fetched");
                                    await returnBalance2();
                                    sw2.WriteLine("Account Balance : " + balance2);
                                    string publicKey = line.TextAfter("Address: ");
                                    if (balance2.Contains("$")) { balance2 = balance2.Replace("$", ""); }
                                    if (balance2.Contains(",")) { balance2 = balance2.Replace(",", ""); }
                                    if (balance2.Contains(".")) { balance2 = balance2.Replace(".", ","); }
                                    double.TryParse(balance2, out double balance2Double); if (balance2Double > 50)
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream("addr_big_balances1.txt", FileMode.Append);
                                            TextWriter sw = new StreamWriter(fs);
                                            sw.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                            sw.WriteLine("Zapper URL : " + url1);
                                            sw.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                            sw.WriteLine("Account Balance : " + balance2Double);
                                            sw.Close();
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                FileStream fs1 = new FileStream("addr_big_balances2.txt", FileMode.Append);
                                                TextWriter sw1 = new StreamWriter(fs1);
                                                sw1.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                sw1.WriteLine("Zapper URL : " + url1);
                                                sw1.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                sw1.WriteLine("Account Balance : " + balance2Double);
                                                sw1.Close();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    FileStream fs3 = new FileStream("addr_big_balances3.txt", FileMode.Append);
                                                    TextWriter sw3 = new StreamWriter(fs3);
                                                    sw3.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw3.WriteLine("Zapper URL : " + url1);
                                                    sw3.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw3.WriteLine("Account Balance : " + balance2Double);
                                                    sw3.Close();
                                                }
                                                catch
                                                {
                                                    FileStream fs4 = new FileStream("addr_big_balances4.txt", FileMode.Append);
                                                    TextWriter sw4 = new StreamWriter(fs4);
                                                    sw4.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw4.WriteLine("Zapper URL : " + url1);
                                                    sw4.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw4.WriteLine("Account Balance : " + balance2Double);
                                                    sw4.Close();

                                                }

                                            }

                                        }

                                    }
                                    sw2.Close();



                                }
                                else
                                {
                                    sw2.WriteLine(line);
                                    sw2.Close();

                                }
                            }

                        }
                        catch (Exception err)
                        {
                            FileStream fs = new FileStream("addr_balances_error2.txt", FileMode.Append);
                            TextWriter sw = new StreamWriter(fs);
                            sw.WriteLine("Error: " + err.ToString());
                            sw.Close();
                            sw2.Close();

                            continue;
                        }



                    }
                }


                //chromiumWebBrowser1.Reload(true);
            }
            else
            {
                button2.Text = "Click After Cloudflare Check";
                button2.Enabled = false;
                // configure
                var settings = new TorSharpSettings
                {
                    ZippedToolsDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TorZipped2"),
                    ExtractedToolsDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TorExtracted2"),
                    PrivoxySettings = { Port = 1227 },
                    TorSettings =
                    {
                      SocksPort = 1228,
                      ControlPort = 1229,
                      ControlPassword = "",
                    },
                };

                // download tools
                await new TorSharpToolFetcher(settings, new HttpClient()).FetchAsync();
                // execute
                var proxy = new TorSharpProxy(settings);
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxySettings.Port))
                };
                var httpClient = new HttpClient(handler);

                if (isTorRunning2 == false)
                {
                    await proxy.ConfigureAndStartAsync();

                    isTorRunning2 = true;
                }


                await Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    string ip = "127.0.0.1";
                    string port = "1227";
                    var rc = chromiumWebBrowser2.GetBrowser().GetHost().RequestContext;
                    var dict = new Dictionary<string, object>
                    {
                    { "mode", "fixed_servers" },
                    { "server", "" + ip + ":" + port + "" }
                    };
                    string error;
                    bool success = rc.SetPreference("proxy", dict, out error);

                });

                url2 = textBox2.Text;
                await chromiumWebBrowser2.LoadUrlAsync(url2);
                button2.Enabled = true;

            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {

            if (button3.Text == "Click After Cloudflare Check")
            {
                stop3 = false;
                button3.Text = "Started";
                button3.Enabled = false;

                string[] inputFiles = Directory.GetFiles(Environment.CurrentDirectory, "addresses3.txt", SearchOption.TopDirectoryOnly);

                int seedpos = -1;

                string seed = "";

                foreach (string file in inputFiles)
                {
                    if (stop3 == true)
                    {
                        break;
                    }
                    string[] lines = File.ReadAllLines(file);
                    int linescount = 0;
                    foreach (string line in lines)
                    {
                        button3.Text = linescount.ToString() + "/" + lines.Length;
                        linescount++;
                        FileStream fs2 = new FileStream("addr_balances3.txt", FileMode.Append);
                        TextWriter sw2 = new StreamWriter(fs2);
                        try
                        {
                            if (line.StartsWith(seedpos.ToString()) || line.StartsWith("Zapper URL : ") || line.StartsWith("Debank URL : ") || line.StartsWith("Account Balance : "))
                            {
                                sw2.Close();
                                continue;
                            }


                            if (line.Contains("Seed: "))
                            {
                                sw2.WriteLine(line);
                                seedpos = Convert.ToInt32(line.Substring(0, line.IndexOf(" ")));
                                seed = line.TextAfter("Seed: ");
                                previousBalance3 = "-1";

                                for (int i = 0; i < 99; i++)
                                {
                                    if (i > 2 && previousBalance3 == "0")
                                    {
                                        break;
                                    }
                                    var account = new Wallet(seed, "").GetAccount(i);
                                    var publicKey = GetAccountAddress3(account.PrivateKey);
                                    sw2.WriteLine(seedpos + " - PrivateKey: " + account.PrivateKey);
                                    url3 = "https://zapper.xyz/account/" + publicKey;
                                    textBox3.Text = url3;
                                    sw2.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                    sw2.WriteLine("Zapper URL : " + url3);
                                    sw2.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);

                                    Console.WriteLine("Navigating Page");
                                    await chromiumWebBrowser3.LoadUrlAsync(url3);
                                    Console.WriteLine("Balance Fetched");
                                    await returnBalance3();
                                    sw2.WriteLine("Account Balance : " + balance3);
                                    if (balance3.Contains("$")) { balance3 = balance3.Replace("$", ""); }
                                    if (balance3.Contains(",")) { balance3 = balance3.Replace(",", ""); }
                                    if (balance3.Contains(".")) { balance3 = balance3.Replace(".", ","); }
                                    double.TryParse(balance3, out double balance3Double); if (balance3Double > 50)
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream("addr_big_balances1.txt", FileMode.Append);
                                            TextWriter sw = new StreamWriter(fs);
                                            sw.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                            sw.WriteLine("Zapper URL : " + url1);
                                            sw.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                            sw.WriteLine("Account Balance : " + balance3Double);
                                            sw.Close();
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                FileStream fs1 = new FileStream("addr_big_balances2.txt", FileMode.Append);
                                                TextWriter sw1 = new StreamWriter(fs1);
                                                sw1.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                sw1.WriteLine("Zapper URL : " + url1);
                                                sw1.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                sw1.WriteLine("Account Balance : " + balance3Double);
                                                sw1.Close();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    FileStream fs3 = new FileStream("addr_big_balances3.txt", FileMode.Append);
                                                    TextWriter sw3 = new StreamWriter(fs3);
                                                    sw3.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw3.WriteLine("Zapper URL : " + url1);
                                                    sw3.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw3.WriteLine("Account Balance : " + balance3Double);
                                                    sw3.Close();
                                                }
                                                catch
                                                {
                                                    FileStream fs4 = new FileStream("addr_big_balances4.txt", FileMode.Append);
                                                    TextWriter sw4 = new StreamWriter(fs4);
                                                    sw4.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw4.WriteLine("Zapper URL : " + url1);
                                                    sw4.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw4.WriteLine("Account Balance : " + balance3Double);
                                                    sw4.Close();

                                                }

                                            }

                                        }

                                    }

                                }
                                sw2.Close();

                            }
                            else
                            {
                                if (line.Contains("Address: "))
                                {
                                    sw2.WriteLine(line);
                                    url3 = "https://zapper.xyz/account/" + line.TextAfter("Address: ");
                                    textBox3.Text = url3;
                                    sw2.WriteLine("Zapper URL : " + url3);
                                    sw2.WriteLine("Debank URL : " + "https://debank.com/profile/" + line.TextAfter("Address: "));
                                    Console.WriteLine("Navigating Page");
                                    await chromiumWebBrowser3.LoadUrlAsync(url3);
                                    Console.WriteLine("Balance Fetched");
                                    await returnBalance3();
                                    sw2.WriteLine("Account Balance : " + balance3);
                                    string publicKey = line.TextAfter("Address: ");
                                    if (balance3.Contains("$")) { balance3 = balance3.Replace("$", ""); }
                                    if (balance3.Contains(",")) { balance3 = balance3.Replace(",", ""); }
                                    if (balance3.Contains(".")) { balance3 = balance3.Replace(".", ","); }
                                    double.TryParse(balance3, out double balance3Double); if (balance3Double > 50)
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream("addr_big_balances1.txt", FileMode.Append);
                                            TextWriter sw = new StreamWriter(fs);
                                            sw.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                            sw.WriteLine("Zapper URL : " + url1);
                                            sw.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                            sw.WriteLine("Account Balance : " + balance3Double);
                                            sw.Close();
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                FileStream fs1 = new FileStream("addr_big_balances2.txt", FileMode.Append);
                                                TextWriter sw1 = new StreamWriter(fs1);
                                                sw1.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                sw1.WriteLine("Zapper URL : " + url1);
                                                sw1.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                sw1.WriteLine("Account Balance : " + balance3Double);
                                                sw1.Close();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    FileStream fs3 = new FileStream("addr_big_balances3.txt", FileMode.Append);
                                                    TextWriter sw3 = new StreamWriter(fs3);
                                                    sw3.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw3.WriteLine("Zapper URL : " + url1);
                                                    sw3.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw3.WriteLine("Account Balance : " + balance3Double);
                                                    sw3.Close();
                                                }
                                                catch
                                                {
                                                    FileStream fs4 = new FileStream("addr_big_balances4.txt", FileMode.Append);
                                                    TextWriter sw4 = new StreamWriter(fs4);
                                                    sw4.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw4.WriteLine("Zapper URL : " + url1);
                                                    sw4.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw4.WriteLine("Account Balance : " + balance3Double);
                                                    sw4.Close();

                                                }

                                            }

                                        }

                                    }
                                    sw2.Close();


                                }
                                else
                                {
                                    sw2.WriteLine(line);
                                    sw2.Close();

                                }
                            }

                        }
                        catch (Exception err)
                        {
                            FileStream fs = new FileStream("addr_balances_error3.txt", FileMode.Append);
                            TextWriter sw = new StreamWriter(fs);
                            sw.WriteLine("Error: " + err.ToString());
                            sw.Close();
                            sw2.Close();

                            continue;
                        }



                    }
                }


            }
            else
            {
                button3.Text = "Click After Cloudflare Check";
                button3.Enabled = false;
                // configure
                var settings = new TorSharpSettings
                {
                    ZippedToolsDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TorZipped3"),
                    ExtractedToolsDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TorExtracted3"),
                    PrivoxySettings = { Port = 1337 },
                    TorSettings =
                    {
                      SocksPort = 1338,
                      ControlPort = 1339,
                      ControlPassword = "",
                    },
                };

                // download tools
                await new TorSharpToolFetcher(settings, new HttpClient()).FetchAsync();
                // execute
                var proxy = new TorSharpProxy(settings);
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxySettings.Port))
                };
                var httpClient = new HttpClient(handler);

                if (isTorRunning3 == false)
                {
                    await proxy.ConfigureAndStartAsync();

                    isTorRunning3 = true;
                }


                await Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    string ip = "127.0.0.1";
                    string port = "1337";
                    var rc = chromiumWebBrowser3.GetBrowser().GetHost().RequestContext;
                    var dict = new Dictionary<string, object>
                    {
                    { "mode", "fixed_servers" },
                    { "server", "" + ip + ":" + port + "" }
                    };
                    string error;
                    bool success = rc.SetPreference("proxy", dict, out error);

                });

                url3 = textBox3.Text;
                await chromiumWebBrowser3.LoadUrlAsync(url3);
                button3.Enabled = true;

            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Click After Cloudflare Check")
            {
                stop4 = false;
                button4.Text = "Started";
                button4.Enabled = false;

                string[] inputFiles = Directory.GetFiles(Environment.CurrentDirectory, "addresses4.txt", SearchOption.TopDirectoryOnly);

                int seedpos = -1;

                string seed = "";

                foreach (string file in inputFiles)
                {
                    if (stop4 == true)
                    {
                        break;
                    }
                    string[] lines = File.ReadAllLines(file);
                    int linescount = 0;
                    foreach (string line in lines)
                    {
                        button4.Text = linescount.ToString() + "/" + lines.Length;
                        linescount++;
                        FileStream fs2 = new FileStream("addr_balances4.txt", FileMode.Append);
                        TextWriter sw2 = new StreamWriter(fs2);
                        try
                        {
                            if (line.StartsWith(seedpos.ToString()) || line.StartsWith("Zapper URL : ") || line.StartsWith("Debank URL : ") || line.StartsWith("Account Balance : "))
                            {
                                sw2.Close();
                                continue;
                            }


                            if (line.Contains("Seed: "))
                            {
                                sw2.WriteLine(line);
                                seedpos = Convert.ToInt32(line.Substring(0, line.IndexOf(" ")));
                                seed = line.TextAfter("Seed: ");
                                previousBalance4 = "-1";

                                for (int i = 0; i < 99; i++)
                                {
                                    if (i > 2 && previousBalance4 == "0")
                                    {
                                        break;
                                    }
                                    var account = new Wallet(seed, "").GetAccount(i);
                                    var publicKey = GetAccountAddress4(account.PrivateKey);
                                    sw2.WriteLine(seedpos + " - PrivateKey: " + account.PrivateKey);
                                    url4 = "https://zapper.xyz/account/" + publicKey;
                                    textBox4.Text = url4;
                                    sw2.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                    sw2.WriteLine("Zapper URL : " + url4);
                                    sw2.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);

                                    Console.WriteLine("Navigating Page");
                                    await chromiumWebBrowser4.LoadUrlAsync(url4);
                                    Console.WriteLine("Balance Fetched");
                                    await returnBalance4();
                                    sw2.WriteLine("Account Balance : " + balance4);
                                    if (balance4.Contains("$")) { balance4 = balance4.Replace("$", ""); }
                                    if (balance4.Contains(",")) { balance4 = balance4.Replace(",", ""); }
                                    if (balance4.Contains(".")) { balance4 = balance4.Replace(".", ","); }
                                    double.TryParse(balance4, out double balance4Double); if (balance4Double > 50)
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream("addr_big_balances1.txt", FileMode.Append);
                                            TextWriter sw = new StreamWriter(fs);
                                            sw.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                            sw.WriteLine("Zapper URL : " + url1);
                                            sw.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                            sw.WriteLine("Account Balance : " + balance4Double);
                                            sw.Close();
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                FileStream fs1 = new FileStream("addr_big_balances2.txt", FileMode.Append);
                                                TextWriter sw1 = new StreamWriter(fs1);
                                                sw1.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                sw1.WriteLine("Zapper URL : " + url1);
                                                sw1.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                sw1.WriteLine("Account Balance : " + balance4Double);
                                                sw1.Close();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    FileStream fs3 = new FileStream("addr_big_balances3.txt", FileMode.Append);
                                                    TextWriter sw3 = new StreamWriter(fs3);
                                                    sw3.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw3.WriteLine("Zapper URL : " + url1);
                                                    sw3.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw3.WriteLine("Account Balance : " + balance4Double);
                                                    sw3.Close();
                                                }
                                                catch
                                                {
                                                    FileStream fs4 = new FileStream("addr_big_balances4.txt", FileMode.Append);
                                                    TextWriter sw4 = new StreamWriter(fs4);
                                                    sw4.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw4.WriteLine("Zapper URL : " + url1);
                                                    sw4.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw4.WriteLine("Account Balance : " + balance4Double);
                                                    sw4.Close();

                                                }

                                            }

                                        }

                                    }

                                }
                                sw2.Close();

                            }
                            else
                            {
                                if (line.Contains("Address: "))
                                {
                                    sw2.WriteLine(line);
                                    url4 = "https://zapper.xyz/account/" + line.TextAfter("Address: ");
                                    textBox4.Text = url4;
                                    sw2.WriteLine("Zapper URL : " + url4);
                                    sw2.WriteLine("Debank URL : " + "https://debank.com/profile/" + line.TextAfter("Address: "));
                                    Console.WriteLine("Navigating Page");
                                    await chromiumWebBrowser4.LoadUrlAsync(url4);
                                    Console.WriteLine("Balance Fetched");
                                    await returnBalance4();
                                    sw2.WriteLine("Account Balance : " + balance4);
                                    string publicKey = line.TextAfter("Address: ");
                                    if (balance4.Contains("$")) { balance4 = balance4.Replace("$", ""); }
                                    if (balance4.Contains(",")) { balance4 = balance4.Replace(",", ""); }
                                    if (balance4.Contains(".")) { balance4 = balance4.Replace(".", ","); }
                                    double.TryParse(balance4, out double balance4Double); if (balance4Double > 50)
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream("addr_big_balances1.txt", FileMode.Append);
                                            TextWriter sw = new StreamWriter(fs);
                                            sw.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                            sw.WriteLine("Zapper URL : " + url1);
                                            sw.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                            sw.WriteLine("Account Balance : " + balance4Double);
                                            sw.Close();
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                FileStream fs1 = new FileStream("addr_big_balances2.txt", FileMode.Append);
                                                TextWriter sw1 = new StreamWriter(fs1);
                                                sw1.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                sw1.WriteLine("Zapper URL : " + url1);
                                                sw1.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                sw1.WriteLine("Account Balance : " + balance4Double);
                                                sw1.Close();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    FileStream fs3 = new FileStream("addr_big_balances3.txt", FileMode.Append);
                                                    TextWriter sw3 = new StreamWriter(fs3);
                                                    sw3.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw3.WriteLine("Zapper URL : " + url1);
                                                    sw3.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw3.WriteLine("Account Balance : " + balance4Double);
                                                    sw3.Close();
                                                }
                                                catch
                                                {
                                                    FileStream fs4 = new FileStream("addr_big_balances4.txt", FileMode.Append);
                                                    TextWriter sw4 = new StreamWriter(fs4);
                                                    sw4.WriteLine(seedpos + " - EVM Address: " + publicKey);
                                                    sw4.WriteLine("Zapper URL : " + url1);
                                                    sw4.WriteLine("Debank URL : " + "https://debank.com/profile/" + publicKey);
                                                    sw4.WriteLine("Account Balance : " + balance4Double);
                                                    sw4.Close();

                                                }

                                            }

                                        }

                                    }
                                    sw2.Close();

                                }
                                else
                                {
                                    sw2.WriteLine(line);
                                    sw2.Close();

                                }
                            }

                        }
                        catch (Exception err)
                        {
                            FileStream fs = new FileStream("addr_balances_error4.txt", FileMode.Append);
                            TextWriter sw = new StreamWriter(fs);
                            sw.WriteLine("Error: " + err.ToString());
                            sw.Close();
                            sw2.Close();

                            continue;
                        }



                    }
                }


            }
            else
            {
                button4.Text = "Click After Cloudflare Check";
                button4.Enabled = false;
                // configure
                var settings = new TorSharpSettings
                {
                    ZippedToolsDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TorZipped4"),
                    ExtractedToolsDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TorExtracted4"),
                    PrivoxySettings = { Port = 1447 },
                    TorSettings =
                    {
                      SocksPort = 1448,
                      ControlPort = 1449,
                      ControlPassword = "",
                    },
                };

                // download tools
                await new TorSharpToolFetcher(settings, new HttpClient()).FetchAsync();
                // execute
                var proxy = new TorSharpProxy(settings);
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxySettings.Port))
                };
                var httpClient = new HttpClient(handler);

                if (isTorRunning4 == false)
                {
                    await proxy.ConfigureAndStartAsync();

                    isTorRunning4 = true;
                }


                await Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    string ip = "127.0.0.1";
                    string port = "1447";
                    var rc = chromiumWebBrowser4.GetBrowser().GetHost().RequestContext;
                    var dict = new Dictionary<string, object>
                    {
                    { "mode", "fixed_servers" },
                    { "server", "" + ip + ":" + port + "" }
                    };
                    string error;
                    bool success = rc.SetPreference("proxy", dict, out error);

                });

                url4 = textBox4.Text;
                await chromiumWebBrowser4.LoadUrlAsync(url4);
                button4.Enabled = true;

            }
        }


    }

    public static class Extension
    {
        public static string TextAfter(this string value, string search)
        {
            return value.Substring(value.IndexOf(search) + search.Length);
        }
    }
}
