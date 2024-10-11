### Descripción del ejercicio

En este ejercicio, se creó un script en Unity que cambia progresivamente el color de un objeto utilizando la clase `Random` para generar valores aleatorios. El script se asocia a un objeto en la escena, y cada 120 frames (o el valor que se defina desde el inspector), se modifica **un solo componente** del color (rojo, verde o azul) de manera aleatoria. 

Para lograrlo, se utiliza un índice aleatorio que selecciona uno de los tres componentes del color RGB, y se asigna un nuevo valor aleatorio a ese componente, mientras los otros dos permanecen sin cambios. Este enfoque permite crear transiciones de color suaves y graduales en lugar de cambios drásticos.

El parámetro de espera en frames es configurable desde el inspector de Unity, permitiendo ajustar la frecuencia del cambio de color sin necesidad de modificar el código.
