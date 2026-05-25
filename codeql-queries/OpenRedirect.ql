/**
 * @name Unvalidated open redirect
 * @description A redirect that uses unvalidated user-supplied input can redirect users to malicious sites.
 * @kind problem
 * @problem.severity error
 * @id local/open-redirect
 */

import csharp

from MethodCall call, Parameter p
where
  call.getTarget().hasFullyQualifiedName("Microsoft.AspNetCore.Mvc.ControllerBase", "Redirect") and
  call.getAnArgument() = p.getAnAccess()
select call, "Redirect uses user-supplied parameter '" + p.getName() + "' without validation."
