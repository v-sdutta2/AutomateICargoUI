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
    [NUnit.Framework.DescriptionAttribute("CAP018_BKG_00008_Attach or Detach AWB from a saved booking")]
    public partial class CAP018_BKG_00008_AttachOrDetachAWBFromASavedBookingFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "CAP018_BKG_00008_Attach or Detach AWB from a saved booking.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "CAP018_BKG_00008_Attach or Detach AWB from a saved booking", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("iCargo Login and Create New Shipment")]
        [NUnit.Framework.CategoryAttribute("CAP018")]
        [NUnit.Framework.CategoryAttribute("CAP018_BKG_00008")]
        [NUnit.Framework.TestCaseAttribute("ANC", "SEA", "PRIORITY", "0316", "2", "20", "Yes", null)]
        public virtual void ICargoLoginAndCreateNewShipment(string origin, string destination, string productCode, string commodity, string piece, string weight, string execute, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CAP018",
                    "CAP018_BKG_00008"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Origin", origin);
            argumentsOfScenario.Add("Destination", destination);
            argumentsOfScenario.Add("ProductCode", productCode);
            argumentsOfScenario.Add("Commodity", commodity);
            argumentsOfScenario.Add("Piece", piece);
            argumentsOfScenario.Add("Weight", weight);
            argumentsOfScenario.Add("Execute", execute);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("iCargo Login and Create New Shipment", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 4
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
#line 5
 testRunner.Given(string.Format("User wants to execute the example \"{0}\"", execute), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.When(string.Format("User switches station if BaseStation other than \"{0}\"", origin), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
 testRunner.When("User enters screen name as \'CAP018\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then("User enters into the  iCargo \'Maintain Booking\' page successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
 testRunner.And("User clicks on New/List button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.And(string.Format("User enters shipment details with Origin \"{0}\", Destination \"{1}\", Product Code \"" +
                            "{2}\" and Agent code", origin, destination, productCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("User enters Shipper and Consignee details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And(string.Format("User enters commodity details with Commodity \"{0}\", Pieces \"{1}\", Weight \"{2}\"", commodity, piece, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 13
 testRunner.And(string.Format("User selects flight for \"{0}\"", productCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.And("User clicks on Save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Scenario to Attach and Detach AWB from a saved booking to generate new AWB number" +
            "")]
        [NUnit.Framework.CategoryAttribute("CAP018")]
        [NUnit.Framework.CategoryAttribute("CAP018_BKG_00008")]
        [NUnit.Framework.TestCaseAttribute("ASQXGUEST", null)]
        public virtual void ScenarioToAttachAndDetachAWBFromASavedBookingToGenerateNewAWBNumber(string agentCode, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CAP018",
                    "CAP018_BKG_00008"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("AgentCode", agentCode);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Scenario to Attach and Detach AWB from a saved booking to generate new AWB number" +
                    "", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 20
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
#line 21
 testRunner.Given("User wants to execute the example \"<Execute>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 22
 testRunner.When("User switches station if BaseStation other than \"<Origin>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
 testRunner.When("User enters screen name as \'CAP018\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then("User enters into the  iCargo \'Maintain Booking\' page successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.And("User enters the AWB number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
 testRunner.And("User clicks on New/List button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
 testRunner.And("User clicks on Attach/Detach button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
 testRunner.And(string.Format("User enters new Agent Code \"{0}\"", agentCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
 testRunner.And("User clicks on Save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
