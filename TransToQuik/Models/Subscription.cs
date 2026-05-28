using System.Collections.Generic;

namespace TransToQuik.Models;

public record Subscription(IReadOnlyList<SubscriptionEntry> Entries);
