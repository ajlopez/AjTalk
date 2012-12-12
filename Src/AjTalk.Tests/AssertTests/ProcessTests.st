
| sem |

sem := Semaphore new.

[sem signal] fork.

sem wait.

