using Models;
using System.ComponentModel;

MediaLibrary library = new MediaLibrary();

ConsoleNotifier consoleNotifier = new ConsoleNotifier();
EmailNotifier emailNotifier = new EmailNotifier("antoine.duff@hotmail.com");
SmsNotifier smsNotifier = new SmsNotifier();
PushNotifier pushNotifier = new PushNotifier();
MultipleNotifier multipleNotifier = new MultipleNotifier();

ReturnService returnService = new ReturnService();

Dvd dvd = new Dvd("1232165463", "Le livre d'Eli", true);
Book book = new Book("1354564154", "Game of Thrones", true);

library.Add(dvd);

dvd.Borrow();
dvd.Return();




//library.Notifier = emailNotifier;

//library.NotifySubscriber("antoine.duff@hotmail.com", "Salut ça va ?");

//Question 7.4.3
// Aucune classe n'a du être modifiée. Sans l'interface INotifier, il faudrait recoder une fonction à chaque changement de manière de notifier.




