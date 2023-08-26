namespace DataAccessObject.Utils;

public class Pagination<T>
{
    private int _pageSize = 10;
    private ICollection<T> _items;

    public int TotalItemsCount { get; set; }

    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (value == 0) throw new InvalidDataException("PageSize equals 0");
            _pageSize = value;
        }
    }

    public int TotalPagesCount
    {
        get
        {
            var count = TotalItemsCount / PageSize;
            if (TotalItemsCount % PageSize == 0)
            {
                return count;
            }

            return count + 1;
        }
    }

    public int PageIndex { get; set; }

    /// <summary>
    /// page number start from 0
    /// </summary>
    public ICollection<T> Items
    {
        get { return _items; }
        set => _items = value;
    }
}