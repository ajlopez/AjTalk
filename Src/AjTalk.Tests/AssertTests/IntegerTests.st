
| sum |

sum := 1.

3 timesRepeat: [ sum := sum + sum ].

[sum == 8] assert.