(function (window, document) {

    "use strict";

    var SicalMenu = {

        init: function (containerId) {

            var container = document.getElementById(containerId);

            if (!container) {
                console.error(
                    "SICAL: No se encontró el contenedor del menú: " +
                    containerId
                );
                return;
            }

            var xhr = new XMLHttpRequest();

            xhr.open(
                "GET",
                sicalApplicationPath + "Forms/MenuData.aspx",
                true
            );

            xhr.onreadystatechange = function () {

                if (xhr.readyState !== 4) {
                    return;
                }

                if (xhr.status === 200) {

                    var menu = JSON.parse(xhr.responseText);

                    SicalMenu.render(
                        container,
                        menu
                    );
                }
                else if (xhr.status === 401) {

                    window.parent.location =
                        "/SicalNet/Login.aspx";
                }
                else {

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