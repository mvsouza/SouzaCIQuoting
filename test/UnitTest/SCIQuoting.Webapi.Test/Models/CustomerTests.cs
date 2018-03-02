using System;
using SCIQuoting.Webapi.Application.Models;
using Xunit;

namespace SCIQuoting.Webapi.Test.Models{
    public class CustomerTest{
        [Fact]
        public void Male_Modifier()
        {
            //Given
            var cust = new Customer(1,
                "Bolinha",
                2,
                DateTime.Now.AddYears(-17),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cust.Modifier,1.5);

            cust = new Customer(1,
                "Bolinha",
                2,
                DateTime.Now.AddYears(-26),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cust.Modifier,1.2);
            cust = new Customer(1,
                "Bolinha",
                2,
                DateTime.Now.AddYears(-36),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cust.Modifier,1);
            cust = new Customer(1,
                "Bolinha",
                2,
                DateTime.Now.AddYears(-61),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cust.Modifier,1.3);
        }
        [Fact]
        public void Female_Modifier()
        {
            var cust = new Customer(1,
                "Bolinha",
                1,
                DateTime.Now.AddYears(-17),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cust.Modifier,1.4);
            cust = new Customer(1,
                "Bolinha",
                1,
                DateTime.Now.AddYears(-26),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cust.Modifier,1);
            cust = new Customer(1,
                "Bolinha",
                1,
                DateTime.Now.AddYears(-61),
                new Address(),
                "",
                "101010101");
            Assert.Equal(cust.Modifier,1.2);
        }
    }
}