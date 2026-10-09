using System;

namespace Nini.Config;

public interface IConfigSource
{
	ConfigCollection Configs { get; }

	bool AutoSave { get; set; }

	AliasText Alias { get; }

	event EventHandler Reloaded;

	event EventHandler Saved;

	void Merge(IConfigSource source);

	void Save();

	void Reload();

	IConfig AddConfig(string name);

	string GetExpanded(IConfig config, string key);

	void ExpandKeyValues();

	void ReplaceKeyValues();
}
