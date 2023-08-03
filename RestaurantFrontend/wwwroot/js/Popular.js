namespace RestaurantFrontend.wwwroot.js
{
    public class Popular
    {
        
        document.addEventListener("DOMContentLoaded", () => {
        const popularList = document.getElementById("popularList");

        
        fetch("/api/popular")
            .then(response => response.json())
            .then(popularItems => {
                popularItems.forEach(item => {
                    const li = document.createElement("li");
                    li.innerHTML = `
                    <strong>${item.name}</strong> - ${item.category} (Rating: ${item.rating})
                `;
                    popularList.appendChild(li);
                });
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });
    });

    }
}
