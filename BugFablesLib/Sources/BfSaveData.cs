using System.Collections.Generic;
using System.Text;
using BugFablesLib.Data;
using BugFablesLib.SaveData;
using static BugFablesLib.Utils;

namespace BugFablesLib;

public abstract class BfSaveData : IBfDataContainer
{
  public enum SaveFileSection
  {
    Header = 0,
    PartyMembers,
    Global,
    MedalShopsAvailables,
    MedalShopsPools,
    Quests,
    Items,
    Medals,
    SamiraSongs,
    StatBonuses,
    Library,
    Flags,
    Flagstrings,
    Flagvars,
    RegionalFlags,
    CrystalBerries,
    Followers,
    EnemyEncounters,
    COUNT
  }

  private const string FlagstringsSeparator = "|SPLIT|";

  public IList<IBfSerializable> Data { get; }

  public BfSerializableDataCollection<CrystalBerryFlagSaveData> CrystalBerries { get; } = new(CommaSeparator);
  public BfSerializableDataCollection<EnemyEncounterSaveData> EnemyEncounters { get; } = new(AtSymbolSeparator);
  public BfSerializableDataCollection<FlagSaveData> Flags { get; } = new(CommaSeparator);
  public BfSerializableDataCollection<FlagstringSaveData> Flagstrings { get; } = new(FlagstringsSeparator);
  public BfSerializableDataCollection<FlagvarSaveData> Flagvars { get; } = new(CommaSeparator);
  public BfSerializableDataCollection<BfAnimId> Followers { get; } = new(CommaSeparator);
  public GlobalSaveData Global { get; } = new();
  public HeaderSaveData Header { get; } = new();
  public ItemsSaveData Items { get; } = new();
  public LibrarySaveData Library { get; } = new();
  public BfSerializableDataCollection<MedalOnHandSaveData> Medals { get; } = new(AtSymbolSeparator);
  public MedalShopsStockSaveData MedalShopsAvailables { get; } = new();
  public MedalShopsStockSaveData MedalShopsPools { get; } = new();
  public BfSerializableDataCollection<PartyMemberSaveData> PartyMembers { get; } = new(AtSymbolSeparator);
  public BoardQuestsSaveData Quests { get; } = new();
  public BfSerializableDataCollection<FlagSaveData> RegionalFlags { get; } = new(CommaSeparator);
  public BfSerializableDataCollection<MusicSaveData> SamiraSongs { get; } = new(AtSymbolSeparator);
  public BfSerializableDataCollection<StatBonusSaveData> StatBonuses { get; } = new(AtSymbolSeparator);

  public BfSaveData()
  {
    Data = new List<IBfSerializable>
    {
      Header,
      PartyMembers,
      Global,
      MedalShopsAvailables,
      MedalShopsPools,
      Quests,
      Items,
      Medals,
      SamiraSongs,
      StatBonuses,
      Library,
      Flags,
      Flagstrings,
      Flagvars,
      RegionalFlags,
      CrystalBerries,
      Followers,
      EnemyEncounters
    };
  }

  public virtual void LoadFromBytes(byte[] data)
  {
    string strData = Encoding.UTF8.GetString(data);
    string[] saveSections = strData.Split('\n');
    for (int i = 0; i < Data.Count; i++)
      Data[i].Deserialize(saveSections[i]);
  }

  public virtual byte[] EncodeToBytes()
  {
    StringBuilder sb = new();
    for (int i = 0; i < Data.Count; i++)
    {
      sb.Append(Data[i].Serialize());

      if (i != Data.Count - 1)
        sb.Append('\n');
    }

    return Encoding.UTF8.GetBytes(sb.ToString());
  }

  public void ResetToDefault()
  {
    foreach (var s in Data)
      s.ResetToDefault();
  }
}
