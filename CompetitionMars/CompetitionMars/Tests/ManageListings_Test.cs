using CompetitionMars.Pages;
using NUnit.Framework;

namespace CompetitionMars.Tests
{
    public class ManageListings_Test
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
            public void ViewListing()
            {
                // go to manage listing page
                ManageListings manageListingsObj = new ManageListings();
                manageListingsObj.GoToManageListingsPage();

                //view listing
                manageListingsObj.ViewListing();
            }



        }
    }
}
