using Trading.Domain.Models;

namespace Trading.Domain.Services;

/// <summary>Интерфейс представляющий индексы</summary>
public interface IMajorIndexService {
    Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);
}
