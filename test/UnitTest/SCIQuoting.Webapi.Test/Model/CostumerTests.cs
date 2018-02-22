using System;
using SCIQuoting.Webapi.Model;
using Xunit;

namespace SCIQuoting.Webapi.Test.Model{
    public class CostumerTest{
        [Fact]
        public void Male_Modifier()
        {
            //Given
            var cost = new Costumer(1,
                "Bolinha",
                2,
                DateTime.Now.AddYears(-17),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cost.Modifier,1.5);

            cost = new Costumer(1,
                "Bolinha",
                2,
                DateTime.Now.AddYears(-26),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cost.Modifier,1.2);
            cost = new Costumer(1,
                "Bolinha",
                2,
                DateTime.Now.AddYears(-36),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cost.Modifier,1);
            cost = new Costumer(1,
                "Bolinha",
                2,
                DateTime.Now.AddYears(-61),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cost.Modifier,1.3);
        }
        [Fact]
        public void Female_Modifier()
        {
            var cost = new Costumer(1,
                "Bolinha",
                1,
                DateTime.Now.AddYears(-17),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cost.Modifier,1.4);
            cost = new Costumer(1,
                "Bolinha",
                1,
                DateTime.Now.AddYears(-26),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cost.Modifier,1);
            cost = new Costumer(1,
                "Bolinha",
                1,
                DateTime.Now.AddYears(-61),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cost.Modifier,1.2);
        }
    }
}