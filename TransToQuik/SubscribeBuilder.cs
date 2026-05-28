using System.Collections.Generic;
using System.Text;
using TransToQuik.Models;

namespace TransToQuik;

public class SubscriptionBuilder
{
    private const char Delimiter = '|';
    private readonly Dictionary<string, HashSet<string>> _subscriptions = [];

    public SubscriptionBuilder Add(string classCode, string secCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(classCode);
        ArgumentException.ThrowIfNullOrWhiteSpace(secCode);

        if (!_subscriptions.TryGetValue(classCode, out var secCodes))
        {
            _subscriptions[classCode] = secCodes = [];
        }

        secCodes.Add(secCode);

        return this;
    }

    public Subscription Build() =>
        new(_subscriptions
            .Select(x => new SubscriptionEntry(x.Key, string.Join(Delimiter, x.Value.OrderBy(v => v))))
            .ToList());
}
