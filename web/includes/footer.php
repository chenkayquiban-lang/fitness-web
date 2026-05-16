    </main>
</div>
<script>
(function () {
    const REFRESH_MS = 7000;
    const path = window.location.pathname.toLowerCase();
    const isListPage = path.endsWith("/index.php") || path.endsWith("/fitness_health_system/") || path.endsWith("/fitness_health_system");
    if (!isListPage) return;
    function userIsTyping() {
        const el = document.activeElement;
        if (!el) return false;
        const tag = el.tagName ? el.tagName.toLowerCase() : "";
        return tag === "input" || tag === "textarea" || tag === "select" || el.isContentEditable;
    }
    const badge = document.createElement("div");
    badge.className = "auto-refresh-badge";
    badge.textContent = "Auto refresh: ON";
    document.body.appendChild(badge);
    setInterval(function () { if (!userIsTyping()) window.location.reload(); }, REFRESH_MS);
})();
</script>
</body>
</html>

// added auto-refresh functionality to list pages (members, health records, goals) with a badge indicator, refreshing every 7 seconds if the user is not actively typing in an input field. This ensures that the latest data is displayed without disrupting user input.
// also updated members list to include edit and delete options, as well as add health option for members
// updated health add feature with member selection and automatic BMI and blood pressure status calculation based on inputs
// enhanced the form layout for better user experience in health add page
// updated goals add feature with member selection and improved form layout
// updated index page to display latest health records with BMI, blood pressure, and date checked