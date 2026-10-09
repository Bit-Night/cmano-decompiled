using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;

namespace Command;

public sealed class RelayCommand : ICommand
{
	private readonly Action<object> action_0;

	private readonly Predicate<object> predicate_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	event EventHandler ICommand.CanExecuteChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler CanExecuteChanged
	{
		add
		{
			CommandManager.RequerySuggested += value;
		}
		remove
		{
			CommandManager.RequerySuggested -= value;
		}
	}

	public RelayCommand(Action<object> execute)
		: this(execute, null)
	{
	}

	public RelayCommand(Action<object> execute, Predicate<object> canExecute)
	{
		if (execute == null)
		{
			throw new ArgumentNullException("execute");
		}
		action_0 = execute;
		predicate_0 = canExecute;
	}

	public bool CanExecute(object parameters)
	{
		if (predicate_0 == null)
		{
			return true;
		}
		return predicate_0(RuntimeHelpers.GetObjectValue(parameters));
	}

	[SpecialName]
	private void raise_CanExecuteChanged(object sender, EventArgs e)
	{
		if (predicate_0 != null)
		{
			predicate_0(RuntimeHelpers.GetObjectValue(sender));
		}
	}

	public void Execute(object parameters)
	{
		action_0(RuntimeHelpers.GetObjectValue(parameters));
	}

	static RelayCommand()
	{
		Class72.smethod_20();
	}
}
