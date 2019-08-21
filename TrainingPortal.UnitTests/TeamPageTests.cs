using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Models;

namespace TrainingPortal.UnitTests
{
    class TeamPageTests
    {
        private Mock<ITeamManager> _fakeTeamManager;
        public TeamPageTests()
        {
            _fakeTeamManager = new Mock<ITeamManager>();
        }
    }
}
