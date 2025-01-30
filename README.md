# MVC.MVP.MVVM in Unity
The project describes different approaches to UI development

# MVC

The Controller is directly passed into the View, creating more dependencies and making scaling and modifications more complex.

Useful for small applications where you need a quick connection between UI elements and logic.

Dependencies:
-HealthView holds a reference to the Controller.
-Controller holds a reference to the HealthView.
-Model has an event Action.
-Model does not know about the Presenter or View.
-Controller subscribes to the Model's event.

Process:
-ButtonView receives input data and sends it to the Controller, which then forwards it to the Model.
-Model processes the business logic and triggers an update event.
-Controller receives the updated Model data.
-Controller updates the HealthView via its reference. The HealthView gets updated.

![image](https://github.com/user-attachments/assets/fbc59c0e-8721-47c7-8b6f-8fe9a5cc3ecd)


# MVP

MVP is the next evolution of MVC, designed for more complex user interfaces.

View is a passive component that must be subscribed to.
No direct data should be passed into it.

View is updated through the IView interface, which must be passed to the Presenter.

Advantages:
-View has no external references, making it easy to replace in the Presenter by simply changing the IView reference.
-Presenter can be tested independently from the View.
-Different Views for different platforms can use the same Presenter.
-Easier to build complex interfaces because MVP separates display logic from business logic.

Dependencies:
-HealthView does not have a reference to the Presenter.
-HealthView implements the IView interface. The Presenter injects itself into the HealthView via IView.
-Both the ButtonView and Model have event Action events.
-Model does not know about the Presenter or View.
-Presenter subscribes to events in both the ButtonView and Model.

Process:
-An event occurs in the ButtonView. The Presenter receives it and sends it to the Model.
-Model processes the business logic and triggers an update event.
-Presenter receives the updated Model data.
-Presenter updates the HealthView via the IView interface.

![image](https://github.com/user-attachments/assets/5e1be0c5-cb9e-4708-ab14-0fc9085c2dfe)


# MVVM

Automatic UI updates when data changes in the ViewModel using UniRx.

-View is further simplified—it only stores UI elements like icons and text.
-ViewModel is easy to test without requiring UI.
-View subscribes to changes in the ViewModel.
-View receives a reference to a reactive property from the ViewModel.

-Clean Architecture:
Separating logic, data, and presentation makes projects easier to scale and maintain.

-Component Reusability:
ViewModel and Model logic can be reused across different parts of the application.

-Testability:
ViewModel and Model can be easily tested since they do not depend on Unity UI.

Dependencies:
-View gets a reference to the ViewModel.
-ViewModel has reactive properties, which the View subscribes to.
-Model has an event Action.
-Model does not know about the ViewModel or View.
-ViewModel subscribes to the Model’s event and updates its reactive property.
-View automatically receives updates from the reactive property.

Process:
-ViewModel receives data and sends it to the Model.
-Model processes the business logic and triggers an update event.
-ViewModel receives the updated Model data.
-ViewModel updates a reactive property.
-View, which is subscribed to the reactive property, automatically updates.

![image](https://github.com/user-attachments/assets/24d1148e-bfa6-4885-b57f-5da3ab725c32)

