namespace MapReduce.NET;

public delegate void ProgressDetails(UpdateType type, uint processedItems, double elapsedSeconds, uint itemsPerSecond);
