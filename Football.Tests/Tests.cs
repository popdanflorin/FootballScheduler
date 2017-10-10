using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Football.Business;

namespace Football.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GenerateScheduleTest()
        {
            //Arrange
            League league = new League();
            Team team1 = new Team { Name = "1" };
            Team team2 = new Team { Name = "2" };
            Team team3 = new Team { Name = "3" };
            Team team4 = new Team { Name = "4" };
            var teams = new List<Team> { team1, team2, team3, team4 };
            league.Teams = teams;

            //Act
            league.GenerateSchedule();

            //Assert
            Assert.IsTrue(league.Matches[0].Home.Name == "1");
            Assert.IsTrue(league.Matches[0].Guest.Name == "4");
            Assert.IsTrue(league.Matches[1].Home.Name == "2");
            Assert.IsTrue(league.Matches[1].Guest.Name == "3");
            Assert.IsTrue(league.Matches[2].Home.Name == "3");
            Assert.IsTrue(league.Matches[2].Guest.Name == "1");
            Assert.IsTrue(league.Matches[3].Home.Name == "2");
            Assert.IsTrue(league.Matches[3].Guest.Name == "4");
            Assert.IsTrue(league.Matches[4].Home.Name == "1");
            Assert.IsTrue(league.Matches[4].Guest.Name == "2");
            Assert.IsTrue(league.Matches[5].Home.Name == "3");
            Assert.IsTrue(league.Matches[5].Guest.Name == "4");

            Assert.IsTrue(league.Matches[6].Home.Name == "4");
            Assert.IsTrue(league.Matches[6].Guest.Name == "1");
            Assert.IsTrue(league.Matches[7].Home.Name == "3");
            Assert.IsTrue(league.Matches[7].Guest.Name == "2");
            Assert.IsTrue(league.Matches[8].Home.Name == "1");
            Assert.IsTrue(league.Matches[8].Guest.Name == "3");
            Assert.IsTrue(league.Matches[9].Home.Name == "4");
            Assert.IsTrue(league.Matches[9].Guest.Name == "2");
            Assert.IsTrue(league.Matches[10].Home.Name == "2");
            Assert.IsTrue(league.Matches[10].Guest.Name == "1");
            Assert.IsTrue(league.Matches[11].Home.Name == "4");
            Assert.IsTrue(league.Matches[11].Guest.Name == "3");
            Assert.IsTrue(league.Matches.Count == 12);
        }

        [TestMethod]
        public void GenerateScheduleTest2()
        {
            //Arrange
            League league = new League();
            Team team1 = new Team { Name = "1" };
            Team team2 = new Team { Name = "2" };
            Team team3 = new Team { Name = "3" };
            Team team4 = new Team { Name = "4" };
            Team team5 = new Team { Name = "5" };
            Team team6 = new Team { Name = "6" };
            Team team7 = new Team { Name = "7" };
            Team team8 = new Team { Name = "8" };
            Team team9 = new Team { Name = "9" };
            Team team10 = new Team { Name = "10" };
            var teams = new List<Team> { team1, team2, team3, team4, team5, team6, team7, team8, team9, team10 };
            league.Teams = teams;

            //Act
            league.GenerateSchedule();

            //Assert
            Assert.IsTrue(league.Matches.Count == 90);
            var result = String.Empty;
            for (int i = 0; i < league.Matches.Count; i++)
            {
                result += (league.Matches[i].Home.Name + " - " + league.Matches[i].Guest.Name) + Environment.NewLine;
            }
        }

        [TestMethod]
        public void GenerateResultTest()
        {
            //arrange
            Match match = new Match();
            match.Home = new Team { Name = "Real Madrid" };
            match.Guest = new Team { Name = "Barcelona" };

            //act
            match.GenerateResult();

            //assert
            Assert.IsTrue(match.Home.GamesPlayed > 0);
            Assert.IsTrue(match.Guest.GamesPlayed > 0);
        }
    }
}
