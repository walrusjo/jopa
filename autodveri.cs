
// PRIVET!
//x2,0,Sliding\6Door\62,15,2:=:Opening[9]%3,0,Таймер,60,,4:[5]6[3]%,y,####2,1.0.9
// Above is your LOAD LINE. Copy it into Visual Script Builder to load your script.
// dco.pe/vsb

public Program()
{
  Runtime.UpdateFrequency = UpdateFrequency.Update10;
}

void Main(string argument)
{
  // Создаем пустую переменную, в нее будем записывать ошибки, если будут
  string ERR_TXT = "";

  // Создаем пустой лист объектов типа IMyTerminalBlock
  List<IMyTerminalBlock> l0 = new List<IMyTerminalBlock>();

  //Создаем пустой объект типа IMyDoorб он пустой потому что равен null
  IMyDoor v0 = null;

  // Используя API игры загружаем из GridTerminalSystem блоки типа IMyDoor
  GridTerminalSystem.GetBlocksOfType<IMyDoor>(l0, filterThis);
  
  
  // ПРоверяем сколько элементов в листе
  if(l0.Count == 0) {
    // Если ноль, то пишем ошибку в переменную ERR_TXT
    ERR_TXT += "no Door blocks found\n";
  }
  else {
    // Если в листе есть элемены, то мы листаем их все
    for(int i = 0; i < l0.Count; i++) {
      // Проверяем свойство CustomName каждого объекта 
      if(l0[i].CustomName == "Sliding Door 2") {
        // если это свойство равно "Sliding Door 2", то мы порисваиваем 
        // найденный объект переменной v0
        v0 = (IMyDoor)l0[i];
        break;
      }
    }
    // если такого блока не найдено, то пишем об этом ошибку
    if(v0 == null) {
      ERR_TXT += "no Door block named Sliding Door 2 found\n";
    }
  }

  //Делаем то же самое, но ищем объект типа IMyTimerBlock
  // с имене "Таймер"
  List<IMyTerminalBlock> l1 = new List<IMyTerminalBlock>();
  IMyTimerBlock myTimer = null;
  GridTerminalSystem.GetBlocksOfType<IMyTimerBlock>(l1, filterThis);
  if(l1.Count == 0) {
    ERR_TXT += "no Timer Block blocks found\n";
  }
  else {
    for(int i = 0; i < l1.Count; i++) {
      if(l1[i].CustomName == "Таймер") {
        myTimer = (IMyTimerBlock)l1[i];
        break;
      }
    }
    if(myTimer == null) {
      ERR_TXT += "no Timer Block block named Таймер found\n";
    }
  }
  
  // Если ERR_TXT не пустая, выводи ее в терминал?
  if(ERR_TXT != "") {
    Echo("Script Errors:\n"+ERR_TXT+"(make sure block ownership is set correctly)");
    return;
  }
  else {Echo("");}
  
  // ПРоверяем если найденный нами ранее объект типа IMyDoor
  // имеет статус DoorStatus.Opening
  if(((IMyDoor)v0).Status == DoorStatus.Opening) {
    myTimer.ApplyAction("Start");
  }
}

bool filterThis(IMyTerminalBlock block) {
  return block.CubeGrid == Me.CubeGrid;
}
