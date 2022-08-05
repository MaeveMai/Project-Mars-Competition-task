using CompetitionMars.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //go to share skill page
                ShareSkill ShareSkillObj = new ShareSkill();
                ShareSkillObj.GoToShareSkillPage();

                ShareSkillObj.CreateShareSkill();
            }



        }
    }
}
