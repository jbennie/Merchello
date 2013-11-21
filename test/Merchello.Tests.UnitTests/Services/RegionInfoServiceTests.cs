﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Merchello.Core.Models;
using Merchello.Core.Services;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Merchello.Tests.UnitTests.Services
{
    [TestFixture]
    public class RegionInfoServiceTests
    {
        private IRegionService _regionService;

        [SetUp]
        public void Init()
        {
            _regionService = new RegionService();
        }
        
        /// <summary>
        /// Test verifies that the service correctly removes countries passed an array of country codes
        /// </summary>
        [Test]
        public void Can_Retrieve_A_RegionList_That_Excludes_Countries()
        {
            //// Arrange
            var excludes = new[] {"SA", "DK"};

            //// Act
            var regions = _regionService.GetAllRegions(excludes);

            //// Assert
            Assert.IsTrue(regions.Any());
            Assert.IsFalse(regions.Contains(new Region("SA")));
            Assert.IsFalse(regions.Contains(new Region("DK")));

        }

        /// <summary>
        /// Test verifies that the service correctly returns the RegionInfo for Denmark given the country code DK
        /// </summary>
        [Test]
        public void Can_Retrieve_Denmark_Region_By_DK_Code()
        {
            //// Arrange
            const string countryCode = "DK";

            //// Act
            var denmark = _regionService.GetRegionByCode(countryCode);

            //// Assert
            Assert.NotNull(denmark);
            Assert.AreEqual(countryCode, denmark.RegionInfo.TwoLetterISORegionName);
        }

        /// <summary>
        /// Test verifies the the US region does have a corresponding collection of provinces
        /// </summary>
        [Test]
        public void US_Region_Has_Provinces_Labeled_States()
        {
            //// Arrange
            const string countryCode = "US";

            //// Act
            var unitedStates = _regionService.GetRegionByCode(countryCode);

            //// Assert
            Assert.IsTrue(unitedStates.Provinces.Any());
            Assert.AreEqual("States", unitedStates.ProvinceLabel);
        }
        
        /// <summary>
        /// Test verifies that the US region contains 62 states (provinces in config xml).  62 includes
        /// US territories and Armed Forces codes
        /// </summary>
        [Test]
        public void US_Region_Contains_62_Provinces()
        {
            //// Arrange
            const string countryCode = "US";
            const int expected = 62;

            //// Act
            var states = _regionService.GetRegionByCode(countryCode).Provinces;

            //// Assert
            Assert.NotNull(states);
            Assert.AreEqual(expected, states.Count());
        }



        [Test]
        public void Can_Serialize_ProvinceCodes()
        {
            var states = _regionService.GetRegionByCode("US").Provinces;

            var json = JsonConvert.SerializeObject(states.ToArray());


            var reversed = JsonConvert.DeserializeObject<IEnumerable<Province>>(json);


            Console.Write(json);
        }
    }

  
}