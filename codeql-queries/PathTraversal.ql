/**
 * @name Potential path traversal
 * @description Reading a file using a path from user input may allow directory traversal attacks.
 * @kind problem
 * @problem.severity error
 * @id local/path-traversal
 */

import csharp

from MethodCall call, Parameter p
where
  call.getTarget().hasFullyQualifiedName("System.IO.File", "ReadAllText") and
  call.getAnArgument() = p.getAnAccess()
select call, "File.ReadAllText uses user-supplied parameter '" + p.getName() + "'. Validate or sanitize the path."
