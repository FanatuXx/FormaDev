using Models;
using System.ComponentModel;

//MediaLibrary library = new MediaLibrary();

//ConsoleNotifier consoleNotifier = new ConsoleNotifier();
//EmailNotifier emailNotifier = new EmailNotifier("antoine.duff@hotmail.com");
//SmsNotifier smsNotifier = new SmsNotifier();
//PushNotifier pushNotifier = new PushNotifier();
//MultipleNotifier multipleNotifier = new MultipleNotifier();

//ReturnService returnService = new ReturnService();

//Dvd dvd = new Dvd("1232165463", "Le livre d'Eli", true);
//Book book = new Book("1354564154", "Game of Thrones", true);

//library.Add(dvd);

//dvd.Borrow();
//dvd.Return();

//library.Notifier = emailNotifier;

//library.NotifySubscriber("antoine.duff@hotmail.com", "Salut ça va ?");

//Question 7.4.3
// Aucune classe n'a du être modifiée. Sans l'interface INotifier, il faudrait recoder une fonction à chaque changement de manière de notifier.


Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("==========================================================================");
Console.WriteLine("          APPLICATION DE GESTION DE MÉDIATHÈQUE - RÉSULTAT FINAL         ");
Console.WriteLine("==========================================================================\n");

// --- 1. Création des abonnés (Partie 1, Partie 8) ---
Console.WriteLine(">>> [1] Création des Abonnés...");
Subscriber abonne1 = new Subscriber("Dupont", "Jean", DateTime.Now);
Subscriber abonne2 = new Subscriber("Martin", "Sophie", DateTime.Now.AddDays(-10));
Console.WriteLine($"Abonné 1 : {abonne1.FirstName} {abonne1.LastName} (inscrit le {abonne1.InscriptionDate.ToShortDateString()})");
Console.WriteLine($"Abonné 2 : {abonne2.FirstName} {abonne2.LastName} (inscrit le {abonne2.InscriptionDate.ToShortDateString()})\n");

// --- 2. Création et gestion des Médiathèques (Partie 2, Partie 3, Partie 5) ---
Console.WriteLine(">>> [2] Initialisation des Médiathèques...");
MediaLibrary mediathequeNord = new MediaLibrary { Name = "Médiathèque Nord" };
MediaLibrary mediathequeSud = new MediaLibrary { Name = "Médiathèque Sud" };

Book livre1 = new Book("111-222", "Le Petit Prince", "Antoine de Saint-Exupéry");
Book livre2 = new Book("333-444", "1984", "George Orwell");
Dvd dvd1 = new Dvd("555-666", "Inception", "Christopher Nolan", 148);
Dvd dvd2 = new Dvd("777-888", "Short Film", "Indie Director", 45);

mediathequeNord.Add(livre1);
mediathequeNord.Add(dvd1);

mediathequeSud.Add(livre2);
mediathequeSud.Add(dvd2);
mediathequeSud.Add(livre1); // Ajout du même livre pour tester la fusion sans doublon

Console.WriteLine($"Médiathèque Nord ({mediathequeNord.Name}) créée avec {mediathequeNord.Medias.Length} médias.");
Console.WriteLine($"Médiathèque Sud ({mediathequeSud.Name}) créée avec {mediathequeSud.Medias.Length} médias.");

// --- 3. Surcharge d'opérateur (Partie 3, Partie 5) ---
Console.WriteLine("\n>>> [3] Fusion des Médiathèques (Opérateur +)...");
MediaLibrary mediathequeGlobale = mediathequeNord + mediathequeSud;
Console.WriteLine($"Médiathèque Fusionnée : \"{mediathequeGlobale.Name}\"");
Console.WriteLine($"LastNamebre total de médias uniques après fusion : {mediathequeGlobale.Medias.Length}");
foreach (var kvp in mediathequeGlobale.Medias)
{
    string type = kvp.Value is Book ? "Book" : "DVD";
    Console.WriteLine($" - [{type}] ISBN: {kvp.Key}, Titre: \"{kvp.Value.Title}\"");
}

// --- 4. Classes Abstraites et Polymorphisme (Partie 4, Partie 6) ---
Console.WriteLine("\n>>> [4] Durées d'emprunt et dates de retour prévues (Polymorphisme & Abstraction)...");
DateTime dateEmprunt = new DateTime(2026, 7, 22);
Console.WriteLine($"Date d'emprunt simulée : {dateEmprunt.ToShortDateString()}");
foreach (var kvp in mediathequeGlobale.Medias)
{
    Media m = kvp.Value;
    int duree = m.LoanDurationDays();
    DateTime dateRetour = m.ReturnDatePreview(dateEmprunt);
    Console.WriteLine($" - \"{m.Title}\" ({m.GetType().Name}) -> Durée: {duree} jours | Retour avant le: {dateRetour.ToShortDateString()}");
}

// --- 5. Interfaces et Système de Notification (Partie 7) ---
Console.WriteLine("\n>>> [5] Configuration des Notificateurs (Contrat INotificateur)...");
var consoleNotif = new ConsoleNotifier();
var emailNotif = new EmailNotifier("alertes@mediatheque.org");
var smsNotif = new SmsNotifier();
var pushNotif = new PushNotifier();

var multipleNotif = new MultipleNotifier();
multipleNotif.Add(consoleNotif);
multipleNotif.Add(emailNotif);
multipleNotif.Add(smsNotif);
multipleNotif.Add(pushNotif);

mediathequeGlobale.Notifier = multipleNotif;
Console.WriteLine("Envoi d'une alerte multi-canal à Sophie Martin :");
mediathequeGlobale.NotifySubscriber("Sophie Martin", "Ceci est un rappel : vous avez un média en retard !");

// --- 6. Événements et Subscriberment Automatique (Partie 11, Partie 12) ---
Console.WriteLine("\n>>> [6] Déclenchement automatique des événements d'emprunt (Action<Media>)...");
// L'événement OnMediaEmprunte est géré de façon transparente lors de l'emprunt d'un média enregistré !
livre1.Borrow(); // Déclenchera OnMediaEmprunte via mediathequeGlobale car le livre y est enregistré !

// --- 7. Sécurisation par Exceptions (Partie 9) ---
Console.WriteLine("\n>>> [7] Tests de robustesse et gestion des exceptions...");
try
{
    Console.WriteLine("Tentative de ré-emprunter le même livre...");
    livre1.Borrow();
}
catch (Exception ex)
{
    Console.WriteLine($" [EXCEPTION CAPTURÉE] {ex.GetType().Name} : {ex.Message}");
}

try
{
    Console.WriteLine("Tentative de retourner un DVD déjà disponible...");
    dvd1.Return();
}
catch (Exception ex)
{
    Console.WriteLine($" [EXCEPTION CAPTURÉE] {ex.GetType().Name} : {ex.Message}");
}

try
{
    Console.WriteLine("Tentative de création d'un DVD avec une durée de -5 minutes...");
    Dvd dvdInvalide = new Dvd("000-000", "Invisible", "Ghost", -5);
}
catch (Exception ex)
{
    Console.WriteLine($" [EXCEPTION CAPTURÉE] {ex.GetType().Name} : {ex.Message}");
}

// --- 8. Chaîne de Traitement de Retour via Délégués (Partie 10) ---
Console.WriteLine("\n>>> [8] Exécution de la chaîne de traitement de retour (Délégués)...");
ReturnService serviceRetour = new ReturnService();

Console.WriteLine("\n--- Traitement classique du retour de 'Le Petit Prince' (Book) ---");
// Le livre est actuellement emprunté (IsAvailable = false). On lance le traitement.
serviceRetour.ProcessReturn(livre1);
Console.WriteLine($"Disponibilité finale du Book : {livre1.IsAvailable}");

Console.WriteLine("\n--- Traitement avec Désinfection de 'Inception' (DVD) ---");
dvd1.Borrow(); // On l'emprunte d'abord
serviceRetour.ProcessReturn(dvd1);
Console.WriteLine($"Disponibilité finale du DVD : {dvd1.IsAvailable}");

Console.WriteLine("\n--- Traitement avec méthodes anonymes (Lambdas) sur '1984' ---");
livre2.Borrow(); // On l'emprunte d'abord
serviceRetour.AnonymousProcessReturn(livre2);
Console.WriteLine($"Disponibilité finale de '1984' : {livre2.IsAvailable}");

Console.WriteLine("\n==========================================================================");
Console.WriteLine("        FIN DE LA DÉMONSTRATION - TOUS LES COMPOSANTS SONT OPÉRATIONNELS  ");
Console.WriteLine("==========================================================================");

