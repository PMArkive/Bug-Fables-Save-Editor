﻿using static BugFablesLib.Utils;

namespace BugFablesLib.SaveData;

public sealed class FlagvarSaveData : IBfData
{
  public int Var { get; set; }
  public void Deserialize(string str) => Var = ParseValueType<int>(str, nameof(Var));
  public string Serialize() => Var.ToString();
  public void ResetToDefault() => Var = 0;
}
