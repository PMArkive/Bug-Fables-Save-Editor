using BugFablesLib.SaveData;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BugFablesSaveEditor.ObservableModels;

public class ObservableEnemyEncounterSaveData : ObservableObject, IModelWrapper<EnemyEncounterSaveData>
{
  public EnemyEncounterSaveData Model { get; }

  public static IModelWrapper<EnemyEncounterSaveData> Factory(EnemyEncounterSaveData model) =>
    new ObservableEnemyEncounterSaveData(model);

  public int NbrSeen
  {
    get => Model.NbrSeen;
    set => SetProperty(Model.NbrSeen, value, Model, (data, i) => data.NbrSeen = i);
  }

  public int NbrDefeated
  {
    get => Model.NbrDefeated;
    set => SetProperty(Model.NbrDefeated, value, Model, (data, i) => data.NbrDefeated = i);
  }

  public ObservableEnemyEncounterSaveData(EnemyEncounterSaveData enemyEncounterSaveData) =>
    Model = enemyEncounterSaveData;
}
