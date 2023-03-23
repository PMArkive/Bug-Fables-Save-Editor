using BugFablesLib.SaveData;
using CommunityToolkit.Mvvm.ComponentModel;
using Reactive.Bindings;

namespace BugFablesSaveEditor.ViewModels;

[ObservableObject]
public partial class ObservableMedalOnHandSaveData : BfObservable
{
  public sealed override MedalOnHandSaveData UnderlyingData { get; }

  [ObservableProperty]
  private ObservableBfResource _medal;

  public ReactiveProperty<int> MedalEquipTarget { get; }

  public ObservableMedalOnHandSaveData(MedalOnHandSaveData medalOnHandSaveData) :
    base(medalOnHandSaveData)
  {
    UnderlyingData = medalOnHandSaveData;
    _medal = new ObservableBfResource(medalOnHandSaveData.Medal);
    MedalEquipTarget = ReactiveProperty.FromObject(UnderlyingData, data => data.MedalEquipTarget);
  }
}
