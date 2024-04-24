﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace iCargoUIAutomation.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("LTE001_ACC_00017_Create a COMAT AWB")]
    public partial class LTE001_ACC_00017_CreateACOMATAWBFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "LTE001_ACC_00017_Create a COMAT AWB.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "LTE001_ACC_00017_Create a COMAT AWB", "Create a New Shipment, Acceptance of that new shipment & screening as a CGO or CG" +
                    "ODG user", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a COMAT AWB")]
        [NUnit.Framework.CategoryAttribute("tag1")]
        [NUnit.Framework.TestCaseAttribute("ASQXGUEST", "10763", "COMATFF", "ANC", "LAX", "COMAT", "None", "NONSCR", "None", "COMAT", "2", "59", "PP", "NONE", "CART", null)]
        public virtual void CreateACOMATAWB(
                    string agentCode, 
                    string shipperCode, 
                    string consigneeCode, 
                    string origin, 
                    string destination, 
                    string productCode, 
                    string sCC, 
                    string commodity, 
                    string shipmentDescription, 
                    string serviceCargoClass, 
                    string piece, 
                    string weight, 
                    string chargeType, 
                    string modeOfPayment, 
                    string cartType, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "tag1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("AgentCode", agentCode);
            argumentsOfScenario.Add("ShipperCode", shipperCode);
            argumentsOfScenario.Add("ConsigneeCode", consigneeCode);
            argumentsOfScenario.Add("Origin", origin);
            argumentsOfScenario.Add("Destination", destination);
            argumentsOfScenario.Add("ProductCode", productCode);
            argumentsOfScenario.Add("SCC", sCC);
            argumentsOfScenario.Add("Commodity", commodity);
            argumentsOfScenario.Add("ShipmentDescription", shipmentDescription);
            argumentsOfScenario.Add("ServiceCargoClass", serviceCargoClass);
            argumentsOfScenario.Add("Piece", piece);
            argumentsOfScenario.Add("Weight", weight);
            argumentsOfScenario.Add("ChargeType", chargeType);
            argumentsOfScenario.Add("ModeOfPayment", modeOfPayment);
            argumentsOfScenario.Add("cartType", cartType);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a COMAT AWB", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given("User lauches the Url of iCargo Staging UI", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.Then("User enters into the  iCargo \'Sign in to icargoas\' page successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
 testRunner.When("User clicks on the oidc button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.Then("A new window is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 11
 testRunner.And("User enters into the  iCargo \'Home\' page successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.When(string.Format("User switches station if BaseStation other than \"{0}\"", origin), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.And("User enters the screen name as \'LTE001\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.Then("User enters into the  iCargo \'Create Shipment\' page successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
 testRunner.When("user clicks on the List button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
 testRunner.And(string.Format("User enters the Participant details with AgentCode \"{0}\", ShipperCode \"{1}\", Cons" +
                            "igneeCode \"{2}\"", agentCode, shipperCode, consigneeCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.And("User clicks on the ContinueParticipant button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
 testRunner.And("User enters the Certificate details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.And("User clicks on the ContinueCertificate button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
 testRunner.And(string.Format("User enters the Shipment details with Origin \"{0}\", Destination \"{1}\", ProductCod" +
                            "e \"{2}\", SCCCode \"{3}\", Commodity \"{4}\", ShipmentDescription\"{5}\", ServiceCargoC" +
                            "lass \"{6}\", Piece \"{7}\", Weight \"{8}\"", origin, destination, productCode, sCC, commodity, shipmentDescription, serviceCargoClass, piece, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
 testRunner.And("User clicks on the ContinueShipment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
 testRunner.And("User clicks on the Select Flight Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.And("User selects an available flight", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.And("User clicks on the ContinueFlightDetails button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.And(string.Format("User enters the Charge details with ChargeType \"{0}\" and ModeOfPayment \"{1}\"", chargeType, modeOfPayment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
 testRunner.And("User clicks on the CalculateCharges button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
 testRunner.And("User clicks on the ContinueChargeDetails button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
 testRunner.And("User enters the Acceptance details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
 testRunner.And("User clicks on the ContinueAcceptanceDetails button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
 testRunner.And("User enters the Screening details for row 1 with screeingMethod as \'Transfer Mani" +
                        "fest Verified\' and ScreeningResult as \'Pass\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 31
 testRunner.And("User clicks on the ContinueScreeningDetails button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.And("User checks the AWB_Verified checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
 testRunner.And("User clicks on the save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.And("User handles the error popups with errorType as \'\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.And("User closes the LTE screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.Then("User logs out from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
