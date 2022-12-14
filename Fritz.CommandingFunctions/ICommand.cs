using Microsoft.Extensions.Logging;

namespace Fritz.CommandingFunctions;

public interface ICommand
{

  ILogger Logger { get; set; }

  /// <summary>
  /// Execute the command asyncronously
  /// </summary>
  /// <returns></returns>
  Task ExecuteAsync();

  void RegisterTriggers(ICommandConfiguration config);

}
