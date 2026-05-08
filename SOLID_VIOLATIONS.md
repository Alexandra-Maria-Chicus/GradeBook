# SOLID Violations

## Violation 1 - Single Responsibility Principle (SRP)

**File:** Controllers/ItemController.cs - GetAll() method

GetAll() does more than it should. Besides returning all items, it also calculates and returns the average value. That's two responsibilities in one method. The average calculation is business logic and shouldn't live in the controller, and the task never required it in the first place.

**Fix:** Removed the statistics calculation entirely. GetAll() now just returns all the objects.

## Violation 2 - Single Responsibility Principle (SRP)

**File:** Controllers/ItemController.cs - GetAll(), GetById()

Both methods were doing manual logging with Console.WriteLine. Logging is not the controller's responsibility.

**Fix:** Removed the logging from the controller entirely.

## Violation 3 - Single Responsibility Principle (SRP)

**File:** Controllers/ItemController.cs

The controller was talking directly to the repository, which meant any business logic had nowhere to live and ended up in the controller. The controller should only handle HTTP concerns.

**Fix:** Introduced a service layer. The controller now talks to IGradeService, and the service talks to IGradeReader. Business logic lives in the service.
