using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for SessionToken entity operations.
    /// </summary>
    public interface ISessionTokenRepository
    {
        /// <summary>
        /// Stores a new session token in the repository.
        /// </summary>
        /// <param name="sessionToken">The session token to save.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task SaveAsync(SessionToken sessionToken, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a session token by its value.
        /// </summary>
        /// <param name="token">The token string.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The session token if found, null otherwise.</returns>
        Task<SessionToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default);

        /// <summary>
        /// Revokes a session token, removing it from the repository.
        /// </summary>
        /// <param name="token">The token string.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task RevokeAsync(string token, CancellationToken cancellationToken = default);
    }
}
