using CompetitionMars.Global;
using CompetitionMars.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static CompetitionMars.Global.GlobalDefinitions;

namespace CompetitionMars.Tests
{
    internal class ShareSkill_Test
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
            public void CreateShareSkill()
            {
                //initialize share skill page
                ShareSkill ShareSkillObj = new ShareSkill();

                //Create Share Skill listing
                ShareSkillObj.CreateShareSkill();

                //compare actual category
                string LatestCategory = ShareSkillObj.GetNewCategory();
                Assert.That(LatestCategory, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "Category")));

                //compare actual title
                string LatestTitle = ShareSkillObj.GetNewTitle();
                Assert.That(LatestTitle, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "Title")));

                //compare actual description
                string LatestDescription = ShareSkillObj.GetNewDescription();
                Assert.That(LatestDescription, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "Description")));
            }

            [Test, Order(2)]
            public void EditListing()
            {
                // initialize manage listing page
                ManageListings manageListingsObj = new ManageListings();

                //edit listing
                manageListingsObj.EditListing();
            }

        }
    }
}
