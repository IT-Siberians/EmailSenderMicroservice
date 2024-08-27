using EmailSenderMicroservice.DataAccess.Repositories.Abstraction;
using EmailSenderMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderMicroservice.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями сообщений в базе данных.
    /// Реализует интерфейс <see cref="IMessageRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных для работы с сущностями сообщений.</param>
    public class MessageRepository(EmailSenderMicroserviceDbContext context) : IMessageRepository
    {
        /// <summary>
        /// Получает все сообщения из базы данных.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <param name="asNoTracking">Указывает, следует ли использовать режим <c>AsNoTracking</c> для запросов.</param>
        /// <returns>Список всех сообщений типа <see cref="Message"/>.</returns>
        public async Task<IEnumerable<Message>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking)
        {
            return await(asNoTracking ? context.Messages.AsNoTracking() : context.Messages)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает сообщение по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Сообщение типа <see cref="Message"/> с указанным идентификатором или <c>null</c>, если сообщение не найдено.</returns>
        public async Task<Message?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Messages
                .Where(x => x.Id == id)                
                .FirstOrDefaultAsync(cancellationToken);            
        }

        /// <summary>
        /// Добавляет новое сообщение в базу данных.
        /// </summary>
        /// <param name="entity">Сущность сообщения для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленного сообщения.</returns>
        public async Task<Guid> AddAsync(Message entity, CancellationToken cancellationToken)
        {

            await context.Messages.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
