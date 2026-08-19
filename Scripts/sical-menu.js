(function (window, document) {

    "use strict";

    var SicalMenu = {

        init: function (containerId) {

            var container =
                document.getElementById(containerId);

            if (!container) {
                console.error(
                    "SICAL: No se encontró el contenedor del menú: " +
                    containerId
                );
                return;
            }

            var xhr =
                new XMLHttpRequest();
            /*
            console.log(
                "Página actual = " +
                window.location.href
            );
            */

            // ==========================================
            // DETERMINAR RAÍZ DE LA APLICACIÓN
            // ==========================================

            var appPath =
                window.SicalAppPath;

            /*
             * NewMenu.aspx define SicalAppPath.
             *
             * Las demás páginas pueden no tener
             * definida dicha variable.
             */
            if (!appPath) {

                var currentPath =
                    window.location.pathname.toLowerCase();

                /*
                 * IIS
                 *
                 * http://localhost/SicalNET/
                 */
                if (
                    currentPath.indexOf(
                        "/sicalnet/"
                    ) === 0
                ) {
                    appPath =
                        "/SicalNET/";
                }
                else {

                    /*
                     * Visual Studio
                     *
                     * https://localhost:44364/
                     */
                    appPath = "/";
                }
            }

            /*
            console.log(
                "SicalAppPath = " +
                appPath
            );
            */


            // ==========================================
            // MENU DATA
            // ==========================================

            var menuDataUrl =
                appPath +
                "MenuData.aspx";
            /*
            console.log(
                "MenuData URL = " +
                menuDataUrl
            );*/


            xhr.open(
                "GET",
                menuDataUrl,
                true
            );


            xhr.onreadystatechange =
                function () {

                    if (
                        xhr.readyState !== 4
                    ) {
                        return;
                    }


                    if (
                        xhr.status === 200
                    ) {

                        var menu =
                            JSON.parse(
                                xhr.responseText
                            );

                        SicalMenu.render(
                            container,
                            menu
                        );
                    }

                    else if (
                        xhr.status === 401
                    ) {

                        window.parent.location =
                            appPath +
                            "Login.aspx";
                    }

                    else {

                        console.error(
                            "SICAL: Error cargando MenuData",
                            xhr.status,
                            menuDataUrl
                        );

                        alert(
                            "Error al cargar el menú. HTTP " +
                            xhr.status
                        );
                    }
                };


            xhr.send(null);
        },

        render: function (container, items) {

            container.innerHTML = "";

            var ul = document.createElement("ul");

            ul.className = "sical-menu";

            for (var i = 0; i < items.length; i++) {

                ul.appendChild(
                    SicalMenu.createItem(items[i])
                );
            }

            container.appendChild(ul);
        },


        createItem: function (item) {

            var li = document.createElement("li");

            li.className = "sical-menu-item";

            /*
             * Si tiene hijos, entonces es un grupo.
             */
            if (item.Children &&
                item.Children.length > 0) {

                li.className += " has-children";

                var span =
                    document.createElement("span");

                span.className =
                    "sical-menu-label";

                span.appendChild(
                    document.createTextNode(item.Label)
                );

                li.appendChild(span);


                var submenu =
                    document.createElement("ul");

                submenu.className =
                    "sical-submenu";


                for (var i = 0;
                    i < item.Children.length;
                    i++) {

                    submenu.appendChild(
                        SicalMenu.createItem(
                            item.Children[i]
                        )
                    );
                }

                li.appendChild(submenu);
            }
            else {

                /*
                 * Elemento normal con URL.
                 */
                var link =
                    document.createElement("a");

                link.href =
                    item.Url || "#";

                if (item.Target) {
                    link.target = item.Target;
                }
                else {
                    // Todas las opciones normales se cargan en MainFrame
                    link.target = "MainFrame";
                }

                link.appendChild(
                    document.createTextNode(
                        item.Label
                    )
                );

                li.appendChild(link);
            }


            return li;
        }

    };


    window.SicalMenu = SicalMenu;

})(window, document);