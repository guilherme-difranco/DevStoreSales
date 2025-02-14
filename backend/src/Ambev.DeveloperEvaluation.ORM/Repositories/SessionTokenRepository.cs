using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of the SessionToken repository using Entity Framework Core.
    /// </summary>
    public class SessionTokenRepository : ISessionTokenRepository
    {
        private readonly DefaultContext _context;

        public SessionTokenRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Stores a session token in the database.
        /// </summary>
        public async Task SaveAsync(SessionToken sessionToken, CancellationToken cancellationToken = default)
        {
            await _context.SessionTokens.AddAsync(sessionToken, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a session token by its token string.
        /// </summary>
        public async Task<SessionToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default)
        {
            return await _context.SessionTokens
                .Where(st => st.Token == token && st.ExpiresAt > DateTime.UtcNow) // Apenas tokens válidos
                .FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Revokes a session token by removing it from the database.
        /// </summary>
        public async Task RevokeAsync(string token, CancellationToken cancellationToken = default)
        {
            var sessionToken = await _context.SessionTokens.FirstOrDefaultAsync(st => st.Token == token, cancellationToken);
            if (sessionToken != null)
            {
                _context.SessionTokens.Remove(sessionToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
