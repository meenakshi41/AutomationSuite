using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DWC_SampleSuite
{
    [TestClass]
    public class UnitTest
    {
        IWebDriver driver;
        public static By viewDefaultNamespacePane { get; set; }
        public static By viewGetUserIDPane { get; set; }
        public static By viewGetCityPane { get; set; }
        public static By viewGetUsersPane { get; set; }
        public static By viewGetInstructionPane { get; set; }
        public static By btnTryItOut { get; set; }
        public static By btnTryItOutGetCity { get; set; }
        public static By inpParamID { get; set; }
        public static By inpParamCity { get; set; }
        public static By btnRunIdExec { get; set; }
        public static By btnRunIdExec_ForCityPane { get; set; }
        public static By btnRunIdExec_ForInstr { get; set; }
        public static By btnRunIdExec_ForUsers { get; set; }

        public static By btnTryItOutGetInst { get; set; }
        public static By btnTryItOutGetUsers { get; set; }
        public static By ResCode { get; set; }
        public static By extrct_cityfromuser {get; set;}
        //  private TestContext testContextInstance { get; set; }
     //   public static List<UserData> TestData { get; set; }
     //   public static string Path = "../..TestData/User Data/UserData.csv";

        public UnitTest()
        {
            Console.WriteLine("Const run");
            try
            {
                viewDefaultNamespacePane = By.XPath("//h4[@id='operations-tag-default']/small/div/p");
                viewGetUserIDPane = By.XPath("//div[@id='operations-default-get_users3']/div/span[2]/a/span");
                viewGetCityPane = By.XPath("//div[@id='operations-default-get_users1']/div/span[2]/a/span");
                btnTryItOut = By.XPath("//div[@id='operations-default-get_users3']/div[2]/div/div/div/div[2]/button");
                btnTryItOutGetCity = By.XPath("//div[@id='operations-default-get_users1']/div[2]/div/div/div/div[2]/button");
                btnTryItOutGetInst = By.XPath("//div[@id='operations-default-get_users2']/div[2]/div/div/div/div[2]/button");
                btnTryItOutGetUsers = By.XPath("//div[@id='operations-default-get_users4']/div[2]/div/div/div/div[2]/button");
                inpParamID = By.XPath("//div[@id='operations-default-get_users3']/div[2]/div/div/div[2]/table/tbody/tr/td[2]/input");
                btnRunIdExec = By.XPath("//div[@id='operations-default-get_users3']/div[2]/div/div[2]/button");
                btnRunIdExec_ForCityPane = By.XPath("//div[@id='operations-default-get_users1']/div[2]/div/div[2]/button");
                btnRunIdExec_ForInstr = By.XPath("//div[@id='operations-default-get_users2']/div[2]/div/div[2]/button");
                btnRunIdExec_ForUsers = By.XPath("//div[@id='operations-default-get_users4']/div[2]/div/div[2]/button");
                ResCode = By.XPath("//*[text()='200']/following::td[@class='col response-col_description']/parent::tr[@class='response']");
                inpParamCity = By.XPath("//div[@id='operations-default-get_users1']/div[2]/div/div/div[2]/table/tbody/tr/td[2]/input");
                extrct_cityfromuser = By.XPath("//div[@id='operations-default-get_users3']/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[2]/div/pre/span[52]");
                //div[@id='operations-default-get_users3']/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[2]/div/pre/span[52]
                viewGetInstructionPane = By.XPath("//div[@id='operations-default-get_users2']/div/span[2]/a/span");
                viewGetUsersPane = By.XPath("//div[@id='operations-default-get_users4']/div/span[2]/a/span");

            }

            catch (Exception e1)

            {
                Console.WriteLine(e1);

            }


        }

        [TestInitialize]
        public void TestMethod1()
        {


            Console.WriteLine("TestInitialize run");
            ChromeOptions CHOptions = new ChromeOptions();
            CHOptions.AddArgument("--ignore-certficate-errors");
            CHOptions.AddArguments("--disable-infobars");
            CHOptions.AddArguments("--disable-restore-session-state");
            CHOptions.AddArgument("--disable-features=InfiniteSessionRestore");
            CHOptions.AddArgument("--disable-extensions");
            CHOptions.AddArgument("--incognito");
            CHOptions.AddUserProfilePreference("exit_type", "Normal");

            driver = new ChromeDriver(CHOptions);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();


            //driver.FindElement(By.XPath("//h4[@id='operations-tag-default']/small/div/p")).Click();
            //driver.FindElement(By.XPath("//div[@id='operations-default-get_users3']/div/span[2]/a/span")).Click();
            //   driver.FindElement(btnTryItOut).Click();

            //    TestMethod1();



        }

        public void LaunchApp()
        {
            driver.Url = "http://bpdts-test-app-v2.herokuapp.com/";
            Thread.Sleep(4000);
            driver.FindElement(viewDefaultNamespacePane).Click();
            Thread.Sleep(4000);

        }

        public void Nav2_Endpt3()
        {
            
            driver.FindElement(viewGetUserIDPane).Click();
            Thread.Sleep(4000);
            driver.FindElement(btnTryItOut).Click();
            Thread.Sleep(4000);
        }

        public void Nav2_Endpt2()
        {

            driver.FindElement(viewGetInstructionPane).Click();
            Thread.Sleep(4000);
            driver.FindElement(btnTryItOutGetInst).Click();
            Thread.Sleep(4000);
        }

        public void Nav2_Endpt4()
        {

            driver.FindElement(viewGetUsersPane).Click();
            Thread.Sleep(4000);
            driver.FindElement(btnTryItOutGetUsers).Click();
            Thread.Sleep(4000);
        }

        public void Nav2_Endpt1()
        {
            driver.FindElement(viewGetCityPane).Click();
            Thread.Sleep(4000);
            driver.FindElement(btnTryItOutGetCity).Click();
            Thread.Sleep(4000);
        }

        public string ValidateResponse_forRandomId(string r)
        {
            driver.FindElement(inpParamID).SendKeys(r);
            driver.FindElement(btnRunIdExec).Click();
            Thread.Sleep(4000);
            try
            {
                Assert.IsTrue(driver.FindElement(ResCode).Displayed);
                Console.WriteLine("Test Successful Test Id "+r+" found");

                Thread.Sleep(4000);
                var str = (driver.FindElement(extrct_cityfromuser).Text).ToString();
                Console.WriteLine(driver.FindElement(extrct_cityfromuser).Text.ToString());
                return str;
             //   
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Test Failed - Record "+r+ " could not be found");
                //  Assert.Fail();
                return null;
            }


        }

        public void ValidateResponse_forGetInstructions()
        {
 
            driver.FindElement(btnRunIdExec_ForInstr).Click();
            Thread.Sleep(4000);
            try
            {
                Assert.IsTrue(driver.FindElement(ResCode).Displayed);
                Console.WriteLine("Test Successful - instructions displayed");


                //   Console.WriteLine(driver.FindElement(extrct_cityfromuser).Text.ToString());
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Test Failed - Data could not be found");
                //  Assert.Fail();
            }


        }

        public void ValidateResponse_forGetAllUsers()
        {

            driver.FindElement(btnRunIdExec_ForUsers).Click();
            Thread.Sleep(4000);
            try
            {
                Assert.IsTrue(driver.FindElement(ResCode).Displayed);
                Console.WriteLine("Test Successful - All users displayed");


                //   Console.WriteLine(driver.FindElement(extrct_cityfromuser).Text.ToString());
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Test Failed - Data could not be found");
                //  Assert.Fail();
            }


        }

        public void ValidateResponse_forRandomCity(string r)
        {
            driver.FindElement(inpParamCity).SendKeys(r);
            driver.FindElement(btnRunIdExec_ForCityPane).Click();
            Thread.Sleep(4000);
            try
            {
                Assert.IsTrue(driver.FindElement(ResCode).Displayed);
                Console.WriteLine("Test Successful - Test City "+r+" found");


                //   Console.WriteLine(driver.FindElement(extrct_cityfromuser).Text.ToString());
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Test Failed - Record could not be found");
                //  Assert.Fail();
            }


        }



        [TestMethod]
        public void Endpoint3Test_viaRandomId()
        {
            LaunchApp();
            Nav2_Endpt3();
            var objrand = new RandomNumberGen();
            string IdToCheck = (objrand.RandomNumber(1, 1000)).ToString();
            string city = ValidateResponse_forRandomId(IdToCheck);


        }

        [TestMethod]
        public void Endpoint3Test_viaRandomId_NegativeTest()
        {
            LaunchApp();
            Nav2_Endpt3();
            var objrand = new RandomNumberGen();
            string IdToCheck = (objrand.RandomNumber(1001, 3000)).ToString();
            string city = ValidateResponse_forRandomId(IdToCheck);
        }

        [TestMethod]
        public void Endpoint1Test_viaRandomCity()
        {
            LaunchApp();
            Nav2_Endpt3();
            var objrand = new RandomNumberGen();
            string IdToCheck = (objrand.RandomNumber(1, 1000)).ToString();
            string city = ValidateResponse_forRandomId(IdToCheck);
            city = city.Trim('"');
            Nav2_Endpt1();
            ValidateResponse_forRandomCity(city);
        }

        [TestMethod]
        public void Endpoint2Test_GetInstructions()
        {
            LaunchApp();
            Nav2_Endpt2();
            ValidateResponse_forGetInstructions();
        }

        [TestMethod]
        public void Endpoint4Test_GetAllUsers()
        {
            LaunchApp();
            Nav2_Endpt4();
            ValidateResponse_forGetAllUsers();
        }

        [TestCleanup]
        public void ExitTest()
        {
            driver.Quit();
        }


    }
}
