using Models;

MediaLibrary library = new MediaLibrary();

ConsoleNotifier consoleNotifier = new ConsoleNotifier();
EmailNotifier emailNotifier = new EmailNotifier("antoine.duff@hotmail.com");
SmsNotifier smsNotifier = new SmsNotifier();
PushNotifier pushNotifier = new PushNotifier();
MultipleNotifier multipleNotifier = new MultipleNotifier();

Dvd dvd = new Dvd("1232165463", "Le livre d'Eli", true);





library.Notifier = emailNotifier;

library.NotifySubscriber("antoine.duff@hotmail.com", "Salut ça va ?");

//Question 7.4.3
// Aucune classe n'a du être modifiée. Sans l'interface INotifier, il faudrait recoder une fonction à chaque changement de manière de notifier.


