//namespace UnitTest.Tests
//{
//    public class DiscountValidatorTests
//    {

//        private DiscountValidator _discountValidator = new();

//        [Fact]
//        public void IsValidCoupon()
//        {
//            var res = _discountValidator.IsValidCoupon("SUMMER50", 100);
//            Assert.Equal(true, res);
//        }
//    }
//}


//namespace UnitTest.Tests
//{
//    public class LeaveCalculatorTests
//    {

//        private LeaveCalculator _leaveCalculator = new();

//        [Theory]
//        [InlineData(0, true, 0)]
//        [InlineData(0, false, 0)]


//        public void CalculateEarnedDays(int month, bool partTime, int expected)
//        {
//            var res = _leaveCalculator.CalculateEarnedDays(month, partTime);
//            Assert.Equal(expected, res);
//        }
//    }
//}


//namespace UnitTest.Tests
//{
//    public class PasswordPolicyTests
//    {

//        private PasswordPolicy _passwordPolicy = new();

//        [Theory]
//        [InlineData("Password", false)]
//        [InlineData("password123", false)]


//        public void IsStrong(string input, bool expected)
//        {
//            var res = _passwordPolicy.IsStrong(input);
//            Assert.Equal(expected, res);
//        }
//    }
//}


//namespace UnitTest.Tests
//{
//    public class EmailParserTests
//    {

//        private EmailParser _emailParser = new();

//        [Theory]
//        [InlineData("user@company.com", "company.com")]
//        [InlineData("user@", "")]


//        public void ExtractDomain(string input, string expected)
//        {
//            var res = _emailParser.ExtractDomain(input);
//            Assert.Equal(expected, res);
//        }
//    }
//}


//namespace UnitTest.Tests
//{
//    public class BankAccountTests
//    {

//        private BankAccount _bankAccount = new(100, 200);

//        [Theory]
//        [InlineData(150, -50)]


//        public void Withdraw(decimal input, decimal expected)
//        {
//            _bankAccount.Withdraw(input);
//            var res = _bankAccount.Balance;
//            Assert.Equal(expected, res);
//        }
//    }
//}


//namespace UnitTest.Tests
//{
//    public class ShoppingCartTests
//    {

//        private ShoppingCart _shoppingCart = new();
//        private readonly List<(string Item, decimal Price)> _items = new();

//        [Theory]
//        [InlineData("chaussettes", 60)]

//        public void AddItem(string item, decimal value)
//        {
//            _shoppingCart.AddItem(item, value);
//        }
//        public void GetTotal()
//        {
//            decimal sum = _items.Sum(x => x.Price);
//            if (sum > 0 && sum < 50m) sum += 5.99m; // Frais de port
//            Assert.Equal(60m, sum);
//        }
//    }
//}


//namespace UnitTest.Tests
//{
//    public class InventoryManagerTests
//    {

//        private InventoryManager _inventoryManager = new InventoryManager(20);

//        [Theory]
//        [InlineData(5, 15)]
//        public void ReserveStock(int input, decimal expected)
//        {
//            _inventoryManager.ReserveStock(input);
//            var res = _inventoryManager.StockQuantity;
//            Assert.Equal(expected, res);
//        }
//    }
//}


using Moq;

namespace UnitTest.Tests
{
    public class RegistrationServiceTests
    {
        [Fact]
        public void ResgisterUserOnce()
        {
            var mockEmail = new Mock<IEmailSender>();
            var service = new RegistrationService(mockEmail.Object);

            var result = service.RegisterUser("Dot@net.com");

            Assert.True(result);
            mockEmail.Verify(x => x.SendEmail("Dot@net.com", "Bienvenue !", "Merci de votre inscription.", Times.Once()));
        }
    }
}




