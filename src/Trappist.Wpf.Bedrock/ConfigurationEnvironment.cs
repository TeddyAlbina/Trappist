﻿using System;

namespace Trappist.Wpf.Bedrock;

/// <summary>
/// Represents an environment variable.
/// </summary>
public sealed record ConfigurationEnvironment(string Name, EnvironmentVariableTarget Target = EnvironmentVariableTarget.User);
