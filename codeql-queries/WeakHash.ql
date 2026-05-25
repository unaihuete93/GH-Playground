/**
 * @name Use of weak MD5 hash algorithm
 * @description MD5 is cryptographically broken and should not be used for security purposes.
 * @kind problem
 * @problem.severity warning
 * @id local/weak-hash
 */

import csharp

from MethodCall call
where call.getTarget().hasFullyQualifiedName("System.Security.Cryptography.MD5", "Create")
select call, "MD5 is a weak hash algorithm. Use SHA-256 or stronger."
