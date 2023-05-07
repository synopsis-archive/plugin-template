using CorePlugin.SampleDb;

namespace CorePlugin.Plugin.Services;

#warning This is just a sample. Replace it with your own.
public class SampleDbService
{
    private readonly SampleDbContext _sampleDb;

    public SampleDbService(SampleDbContext sampleDb)
    {
        _sampleDb = sampleDb;
#warning Doing EnsureCreated() here is not a good practice. You should use migrations instead.
        sampleDb.Database.EnsureCreated();
    }

    public string GetSampleDbItem() => _sampleDb.SampleDbItems.First().Description;
}
