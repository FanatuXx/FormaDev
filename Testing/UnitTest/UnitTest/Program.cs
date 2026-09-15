//public class PhoneFormatter
//{
//    public string FormatFrenchNumber(string phone)
//    {
//        if (string.IsNullOrWhiteSpace(phone)) return string.Empty;
//        var cleaned = phone.Replace(" ", "").Replace("-", "").Replace(".", "");
//        if (cleaned.StartsWith("+33"))
//        {
//            cleaned = "0" + cleaned.Substring(3);
//        }
//        return cleaned;
//    }
//}


//using Microsoft.VisualBasic;

//public class DiscountValidator
//{
//    public bool IsValidCoupon(string couponCode, decimal orderAmount)
//    {
//        if (string.IsNullOrEmpty(couponCode)) return false;
//        // BUG SUBTIL : La promo "SUMMER50" exige un montant >= 100, mais la condition a une inversion!
//    if (couponCode == "SUMMER50" && orderAmount > 150)
//        {
//            return true;
//        }
//        return couponCode.Length == 6;
//    }
//}


//public class LeaveCalculator
//{
//    public int CalculateEarnedDays(int monthsWorked, bool isPartTime)
//    {
//        if (monthsWorked <= 0) return 0;
//        double baseRate = isPartTime ? 1.5 : 2.5;
//        return (int)Math.Floor(monthsWorked * baseRate);
//    }
//}

//public class PasswordPolicy
//{
//    public bool IsStrong(string password)
//    {
//        if (string.IsNullOrEmpty(password) || password.Length < 8) return false;
//        bool hasDigit = password.Any(char.IsDigit);
//        bool hasUpper = password.Any(char.IsUpper);
//        // BUG SUBTIL : Utilise un OU logique (||) au lieu d'un ET (&&) !
//        return hasDigit && hasUpper;
//    }
//}

//public class EmailParser
//{
//    public string ExtractDomain(string email)
//    {
//        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
//            throw new ArgumentException("Format d'email invalide.");
//        var parts = email.Split('@');
//        if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[1]))
//            throw new ArgumentException("Format d'email invalide.");
//        return parts[1].ToLower();
//    }
//}


//public class ShoppingCart
//{
//    private readonly List<(string Item, decimal Price)> _items = new();
//    public void AddItem(string item, decimal price)
//    {
//        if (price < 0) throw new ArgumentException("Prix invalide.");
//        _items.Add((item, price));
//    }
//    public decimal GetTotal()
//    {
//        decimal sum = _items.Sum(x => x.Price);
//        if (sum > 0 && sum < 50m) sum += 5.99m; // Frais de port
//        return sum;
//    }
//}



//public class InventoryManager
//{
//    public int StockQuantity { get; private set; }
//    public InventoryManager(int initialStock)
//    {
//        StockQuantity = initialStock;
//    }

//    public void ReserveStock(int quantity)
//    {
//        if (quantity <= 0) throw new ArgumentException("Quantité invalide.");
//        if (quantity > StockQuantity) throw new InvalidOperationException("Stock insuffisant.");
//        // BUG SUBTIL : Additionne la quantité au lieu de la soustraire !
//        StockQuantity -= quantity;
//    }
//}


using Moq;

public interface IEmailSender
{
    void SendEmail(string to, string subject, string body);
}
public class RegistrationService
{
    private readonly IEmailSender _emailSender;
    public RegistrationService(IEmailSender emailSender) => _emailSender = emailSender;
    public bool RegisterUser(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;
        _emailSender.SendEmail(email, "Bienvenue !", "Merci de votre inscription.");
        return true;
    }
}
