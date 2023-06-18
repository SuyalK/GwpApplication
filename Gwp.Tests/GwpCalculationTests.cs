using Gwp.Business;
using Gwp.DAL;
using Gwp.Model;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System.Diagnostics.Metrics;

namespace Gwp.Tests
{
    public class GwpCalculationTests
    {
        string country;
        string[] lineOfBusinesses;
        Mock<IGwpData> mockGwpData = null;
        List<CountryGwp> countryGwpList = null;

        [SetUp]
        public void Setup()
        {
            country = "ae";
            lineOfBusinesses = new string[] { "transport", "freight" };
            mockGwpData = new Mock<IGwpData>();

            countryGwpList = new List<CountryGwp>()
            {
                new CountryGwp()
                {
                    country= "ae",
                    variableId ="gwp",
                    variableName = "Direct Premiums",
                    lineOfBusiness = "transport",
                    Y2000 = "",
                    Y2001 = "",
                    Y2002 = "",
                    Y2003 = "",
                    Y2004 = "",
                    Y2005 = "",
                    Y2006 = "",
                    Y2007 = "231441262.7",
                    Y2008 = "268744928.7",
                    Y2009 = "284448918.2",
                    Y2010 = "314413884.1",
                    Y2011 = "327740154.4",
                    Y2012 = "326126300.6",
                    Y2013 = "240322742.6",
                    Y2014 = "234164748.7",
                    Y2015 = ""
                },
                new CountryGwp()
                {
                    country= "ae",
                    variableId ="gwp",
                    variableName = "Direct Premiums",
                    lineOfBusiness = "freight",
                    Y2000 = "",
                    Y2001 = "",
                    Y2002 = "",
                    Y2003 = "",
                    Y2004 = "",
                    Y2005 = "",
                    Y2006 = "",
                    Y2007 = "217119663.1",
                    Y2008 = "252114975.9",
                    Y2009 = "266847201.6",
                    Y2010 = "294957933.5",
                    Y2011 = "307459573.3",
                    Y2012 = "305945585",
                    Y2013 = "225451556.4",
                    Y2014 = "219674619.6",
                    Y2015 = ""
                }
            };
        }

        [Test]
        public void CalculateAverageGwp_Success()
        {
            // Arrange
            mockGwpData.Setup(x => x.GetGwpByCountry(It.IsAny<string>())).Returns(
                countryGwpList );

            GwpCalculation gwpCalculation = new GwpCalculation(mockGwpData.Object);

            // Act
            var expertCallPriceList = gwpCalculation.CalculateAverageGwp(country, lineOfBusinesses);

            // Assert
            Assert.IsNotNull(expertCallPriceList);
            Assert.NotZero(expertCallPriceList.Count);
        }
    }
}