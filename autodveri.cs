//x2,0,Sliding\6Door\62,15,2:=:Opening[9]%3,0,Таймер,60,,4:[5]6[3]%,y,####2,1.0.9
// Above is your LOAD LINE. Copy it into Visual Script Builder to load your script.
// dco.pe/vsb

public Program()
{
  Runtime.UpdateFrequency = UpdateFrequency.Update10;
}

void Main(string argument)
{
  // block declarations
  string ERR_TXT = "";
  List<IMyTerminalBlock> l0 = new List<IMyTerminalBlock>();
  IMyDoor v0 = null;
  GridTerminalSystem.GetBlocksOfType<IMyDoor>(l0, filterThis);
  if(l0.Count == 0) {
    ERR_TXT += "no Door blocks found\n";
  }
  else {
    for(int i = 0; i < l0.Count; i++) {
      if(l0[i].CustomName == "Sliding Door 2") {
        v0 = (IMyDoor)l0[i];
        break;
      }
    }
    if(v0 == null) {
      ERR_TXT += "no Door block named Sliding Door 2 found\n";
    }
  }
  List<IMyTerminalBlock> l1 = new List<IMyTerminalBlock>();
  IMyTimerBlock v1 = null;
  GridTerminalSystem.GetBlocksOfType<IMyTimerBlock>(l1, filterThis);
  if(l1.Count == 0) {
    ERR_TXT += "no Timer Block blocks found\n";
  }
  else {
    for(int i = 0; i < l1.Count; i++) {
      if(l1[i].CustomName == "Таймер") {
        v1 = (IMyTimerBlock)l1[i];
        break;
      }
    }
    if(v1 == null) {
      ERR_TXT += "no Timer Block block named Таймер found\n";
    }
  }
  
  // display errors
  if(ERR_TXT != "") {
    Echo("Script Errors:\n"+ERR_TXT+"(make sure block ownership is set correctly)");
    return;
  }
  else {Echo("");}
  
  // logic
  if(((IMyDoor)v0).Status == DoorStatus.Opening) {
    v1.ApplyAction("Start");
  }
}

bool filterThis(IMyTerminalBlock block) {
  return block.CubeGrid == Me.CubeGrid;
}
