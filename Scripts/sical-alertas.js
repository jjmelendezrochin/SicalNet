(function (window, document) {

    "use strict";

    window.SicalAlert = {

        mostrar: function (mensaje, tipo, titulo) {

            tipo = tipo || "info";

            var configuracion = {
                exito: {
                    titulo: "Correcto",
                    icono: "✓"
                },

                error: {
                    titulo: "Error",
                    icono: "×"
                },

                advertencia: {
                    titulo: "Atención",
                    icono: "!"
                },

                info: {
                    titulo: "Información",
                    icono: "i"
                }
            };

            var config = configuracion[tipo] || configuracion.info;

            if (!titulo) {
                titulo = config.titulo;
            }


            /* Overlay */
            var overlay = document.createElement("div");
            overlay.className = "sical-alert-overlay";


            /* Caja */
            var alerta = document.createElement("div");
            alerta.className =
                "sical-alert sical-alert-" + tipo;


            /* Icono */
            var icono = document.createElement("div");
            icono.className = "sical-alert-icon";
            icono.innerHTML = config.icono;


            /* Contenido */
            var contenido = document.createElement("div");
            contenido.className = "sical-alert-content";


            var tituloElemento = document.createElement("div");
            tituloElemento.className = "sical-alert-title";
            tituloElemento.innerHTML = titulo;


            var mensajeElemento = document.createElement("div");
            mensajeElemento.className = "sical-alert-message";

            /* textContent evita interpretar HTML */
            mensajeElemento.textContent = mensaje;


            contenido.appendChild(tituloElemento);
            contenido.appendChild(mensajeElemento);


            /* Botón */
            var boton = document.createElement("button");

            boton.type = "button";
            boton.className = "sical-alert-button";
            boton.innerHTML = "Aceptar";


            alerta.appendChild(icono);
            alerta.appendChild(contenido);
            alerta.appendChild(boton);

            overlay.appendChild(alerta);

            document.body.appendChild(overlay);


            /* Animación */
            setTimeout(function () {
                overlay.className += " visible";
            }, 10);


            function cerrar() {

                overlay.className =
                    overlay.className.replace(
                        " visible",
                        ""
                    );

                setTimeout(function () {

                    if (overlay.parentNode) {
                        overlay.parentNode.removeChild(overlay);
                    }

                }, 200);
            }


            boton.onclick = cerrar;


            /* Cerrar con Escape */
            function teclado(e) {

                e = e || window.event;

                if (e.key === "Escape" ||
                    e.keyCode === 27) {

                    cerrar();

                    if (document.removeEventListener) {
                        document.removeEventListener(
                            "keydown",
                            teclado
                        );
                    }
                }
            }

            if (document.addEventListener) {

                document.addEventListener(
                    "keydown",
                    teclado
                );
            }


            /* Enfocar botón */
            setTimeout(function () {
                boton.focus();
            }, 50);
        },

        confirmar: function (mensaje, titulo, callbackAceptar) {

            titulo = titulo || "Confirmar operación";

            /* Overlay */
            var overlay = document.createElement("div");
            overlay.className = "sical-alert-overlay";

            /* Caja */
            var alerta = document.createElement("div");
            alerta.className = "sical-alert sical-alert-advertencia";

            /* Icono */
            var icono = document.createElement("div");
            icono.className = "sical-alert-icon";
            icono.innerHTML = "?";

            /* Contenido */
            var contenido = document.createElement("div");
            contenido.className = "sical-alert-content";

            var tituloElemento = document.createElement("div");
            tituloElemento.className = "sical-alert-title";
            tituloElemento.innerHTML = titulo;

            var mensajeElemento = document.createElement("div");
            mensajeElemento.className = "sical-alert-message";
            mensajeElemento.textContent = mensaje;

            contenido.appendChild(tituloElemento);
            contenido.appendChild(mensajeElemento);

            /* Contenedor de botones */
            var botones = document.createElement("div");
            botones.className = "sical-alert-buttons";

            /* Botón cancelar */
            var botonCancelar = document.createElement("button");
            botonCancelar.type = "button";
            botonCancelar.className =
                "sical-alert-button sical-alert-button-cancelar";
            botonCancelar.innerHTML = "Cancelar";

            /* Botón aceptar */
            var botonAceptar = document.createElement("button");
            botonAceptar.type = "button";
            botonAceptar.className =
                "sical-alert-button sical-alert-button-aceptar";
            botonAceptar.innerHTML = "Aceptar";

            botones.appendChild(botonCancelar);
            botones.appendChild(botonAceptar);

            /* Los botones quedan dentro del área de contenido */
            contenido.appendChild(botones);

            alerta.appendChild(icono);
            alerta.appendChild(contenido);            

            overlay.appendChild(alerta);

            document.body.appendChild(overlay);

            /* Mostrar con animación */
            setTimeout(function () {
                overlay.className += " visible";
            }, 10);

            function cerrar(callback) {

                overlay.className =
                    overlay.className.replace(
                        " visible",
                        ""
                    );

                setTimeout(function () {

                    if (overlay.parentNode) {
                        overlay.parentNode.removeChild(overlay);
                    }

                    if (callback) {
                        callback();
                    }

                }, 200);
            }

            botonCancelar.onclick = function () {
                cerrar();
            };

            botonAceptar.onclick = function () {

                cerrar(function () {

                    if (callbackAceptar) {
                        callbackAceptar();
                    }

                });
            };

            /* Escape = Cancelar */
            function teclado(e) {

                e = e || window.event;

                if (e.key === "Escape" ||
                    e.keyCode === 27) {

                    cerrar();

                    if (document.removeEventListener) {
                        document.removeEventListener(
                            "keydown",
                            teclado
                        );
                    }
                }
            }

            if (document.addEventListener) {

                document.addEventListener(
                    "keydown",
                    teclado
                );
            }

            /* Enfocar Aceptar */
            setTimeout(function () {
                botonAceptar.focus();
            }, 50);
        }

    };

})(window, document);