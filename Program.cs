using mis_221_pa_5_aparker2024;

Trainer[] trainers = new Trainer[50];
Menu menuOption = new Menu();

menuOption.MenuToString();
menuOption.SetMenuOption(int.Parse(Console.ReadLine()));
menuOption.RouteEm(trainers);

