namespace DatabaseViewer.Data
{
    public interface IDatabaseRepository
    {
        DatabaseMap GetMetaOfAllTables();
    }
}