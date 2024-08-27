using EmailSenderMicroservice.DataAccess.Repositories.Abstraction;
using EmailSenderMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderMicroservice.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями настроек в базе данных.
    /// Реализует интерфейс <see cref="ISettingRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных для работы с сущностями настроек.</param>
    public class SettingRepository(EmailSenderMicroserviceDbContext context) : ISettingRepository
    {
        /// <summary>
        /// Добавляет новую настройку в базу данных.
        /// </summary>
        /// <param name="entity">Сущность настройки для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленной настройки.</returns>
        public async Task<Guid> AddAsync(Setting entity, CancellationToken cancellationToken)
        {
            await context.Settings.AddAsync(entity);
            await context.SaveChangesAsync();
            
            return entity.Id;
        }

        /// <summary>
        /// Получает все настройки из базы данных.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <param name="asNoTracking">Указывает, следует ли использовать режим <c>AsNoTracking</c> для запросов.</param>
        public async Task<IEnumerable<Setting>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? context.Settings.AsNoTracking() : context.Settings)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает последнюю настройку из базы данных, отсортированную по дате создания.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Последняя настройка типа <see cref="Setting"/> или <c>null</c>, если настройки не найдены.</returns>
        public async Task<Setting?> GetCurrentAsync(CancellationToken cancellationToken)
        {
            return await context.Settings
                .OrderBy(z => z.CreattionDate)
                .LastOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Получает настройку по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор настройки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Настройка типа <see cref="Setting"/> с указанным идентификатором или <c>null</c>, если настройка не найдена.</returns>
        public async Task<Setting?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Settings
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Обновляет существующую настройку в базе данных.
        /// </summary>
        /// <param name="entity">Обновлённая сущность настройки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns><c>true</c>, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(Setting entity, CancellationToken cancellationToken)
        {
            await context.Settings
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                    .SetProperty(a => a.Connection, a => entity.Connection)
                    .SetProperty(a => a.UseSSL, a => entity.UseSSL)
                    .SetProperty(a => a.Login, a => entity.Login)
                    .SetProperty(a => a.Password, a => entity.Password)
                    .SetProperty(a => a.Password, a => entity.Password)
                    .SetProperty(a => a.CreattionDate, a => entity.CreattionDate)
                );

            return true;
        }
    }
}
